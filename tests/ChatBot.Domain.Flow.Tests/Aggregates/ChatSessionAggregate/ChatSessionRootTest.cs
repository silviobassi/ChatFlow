using ChatBot.CommonUtils.Tests.Fakers;
using ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate;
using Shouldly;

namespace ChatBot.Domain.Flow.Tests.Aggregates.ChatSessionAggregate;

public sealed class ChatSessionRootTest
{
    private readonly ChatSessionRootFaker _faker = new();

    #region CreateSession – Valid

    [Fact]
    public void CreateSession_WithValidParameters_ShouldCreateActiveSession()
    {
        // Arrange
        var tenantId = _faker.TenantId;
        var phoneNumber = _faker.PhoneNumber;
        var startNodeId = _faker.NodeId;
        var startFlowId = _faker.FlowId;

        // Act
        var session = ChatSessionRoot.CreateSession(tenantId, phoneNumber, startNodeId, startFlowId);

        // Assert
        session.Id.ShouldNotBe(Guid.Empty);
        session.UserPhoneNumber.ShouldBe(phoneNumber);
        session.CurrentNodeId.ShouldBe(startNodeId);
        session.CurrentFlowId.ShouldBe(startFlowId);
        session.TenantId.ShouldBe(tenantId);
        session.IsActive.ShouldBeTrue();
        session.CreatedAt.ShouldBeInRange(DateTime.UtcNow.AddSeconds(-5), DateTime.UtcNow);
        session.LastInteractionAt.ShouldBeInRange(DateTime.UtcNow.AddSeconds(-5), DateTime.UtcNow);
        session.ContextData.ShouldBeEmpty();
    }

    [Fact]
    public void CreateSession_ShouldGenerateUniqueIds()
    {
        // Act
        var session1 = _faker.CreateValidSession();
        var session2 = _faker.CreateValidSession();

        // Assert
        session1.Id.ShouldNotBe(session2.Id);
    }

    #endregion

    #region CreateSession – Invalid

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void CreateSession_WithInvalidTenantId_ShouldThrow(long invalidTenantId)
    {
        // Act & Assert
        Should.Throw<InvalidOperationException>(() => _faker.CreateSession(tenantId: invalidTenantId));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateSession_WithInvalidPhoneNumber_ShouldThrow(string? invalidPhone)
    {
        // Act & Assert
        Should.Throw<InvalidOperationException>(() => _faker.CreateSession(phoneNumber: invalidPhone!));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateSession_WithInvalidStartNodeId_ShouldThrow(string? invalidNodeId)
    {
        // Act & Assert
        Should.Throw<InvalidOperationException>(() => _faker.CreateSession(startNodeId: invalidNodeId!));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateSession_WithInvalidStartFlowId_ShouldThrow(string? invalidFlowId)
    {
        // Act & Assert
        Should.Throw<InvalidOperationException>(() => _faker.CreateSession(startFlowId: invalidFlowId!));
    }

    #endregion

    #region TransitionToNode

    [Fact]
    public void TransitionToNode_WithValidNodeId_ShouldUpdateCurrentNodeId()
    {
        // Arrange
        var session = _faker.CreateValidSession();
        var previousInteraction = session.LastInteractionAt;
        var nextNodeId = _faker.NodeId;

        // Act
        session.TransitionToNode(nextNodeId);

        // Assert
        session.CurrentNodeId.ShouldBe(nextNodeId);
        session.LastInteractionAt.ShouldBeGreaterThanOrEqualTo(previousInteraction);
    }

    [Fact]
    public void TransitionToNode_ShouldNotChangeFlowId()
    {
        // Arrange
        var session = _faker.CreateValidSession();
        var originalFlowId = session.CurrentFlowId;

        // Act
        session.TransitionToNode(_faker.NodeId);

        // Assert
        session.CurrentFlowId.ShouldBe(originalFlowId);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void TransitionToNode_WithInvalidNodeId_ShouldThrow(string? invalidNodeId)
    {
        // Arrange
        var session = _faker.CreateValidSession();

        // Act & Assert
        Should.Throw<InvalidOperationException>(() => session.TransitionToNode(invalidNodeId!));
    }

    [Fact]
    public void TransitionToNode_WhenSessionIsInactive_ShouldThrow()
    {
        // Arrange
        var session = _faker.CreateValidSession();
        session.CheckExpiration(timeoutInMinutes: -1); // Force expiration

        // Act & Assert
        session.IsActive.ShouldBeFalse();
        Should.Throw<InvalidOperationException>(() => session.TransitionToNode(_faker.NodeId));
    }

    #endregion

    #region TransitionToFlow

    [Fact]
    public void TransitionToFlow_WithValidParameters_ShouldUpdateFlowAndNode()
    {
        // Arrange
        var session = _faker.CreateValidSession();
        var previousInteraction = session.LastInteractionAt;
        var nextFlowId = _faker.FlowId;
        var entryNodeId = _faker.NodeId;

        // Act
        session.TransitionToFlow(nextFlowId, entryNodeId);

        // Assert
        session.CurrentFlowId.ShouldBe(nextFlowId);
        session.CurrentNodeId.ShouldBe(entryNodeId);
        session.LastInteractionAt.ShouldBeGreaterThanOrEqualTo(previousInteraction);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void TransitionToFlow_WithInvalidFlowId_ShouldThrow(string? invalidFlowId)
    {
        // Arrange
        var session = _faker.CreateValidSession();

        // Act & Assert
        Should.Throw<InvalidOperationException>(() => session.TransitionToFlow(invalidFlowId!, _faker.NodeId));
    }

    [Fact]
    public void TransitionToFlow_WhenSessionIsInactive_ShouldThrow()
    {
        // Arrange
        var session = _faker.CreateValidSession();
        session.CheckExpiration(timeoutInMinutes: -1); // Force expiration

        // Act & Assert
        session.IsActive.ShouldBeFalse();
        Should.Throw<InvalidOperationException>(() => session.TransitionToFlow(_faker.FlowId, _faker.NodeId));
    }

    #endregion

    #region AddContextData / GetContextData

    [Fact]
    public void AddContextData_ShouldStoreValue()
    {
        // Arrange
        var session = _faker.CreateValidSession();
        var key = _faker.ContextKey;
        var value = _faker.ContextValue;

        // Act
        session.AddContextData(key, value);

        // Assert
        session.ContextData.ShouldContainKeyAndValue(key, value);
        session.GetContextData(key).ShouldBe(value);
    }

    [Fact]
    public void AddContextData_WithExistingKey_ShouldOverwriteValue()
    {
        // Arrange
        var session = _faker.CreateValidSession();
        var key = _faker.ContextKey;
        var originalValue = _faker.ContextValue;
        var updatedValue = _faker.ContextValue;
        session.AddContextData(key, originalValue);

        // Act
        session.AddContextData(key, updatedValue);

        // Assert
        session.GetContextData(key).ShouldBe(updatedValue);
        session.ContextData.Count.ShouldBe(1);
    }

    [Fact]
    public void AddContextData_ShouldUpdateLastInteractionAt()
    {
        // Arrange
        var session = _faker.CreateValidSession();
        var previousInteraction = session.LastInteractionAt;

        // Act
        session.AddContextData(_faker.ContextKey, _faker.ContextValue);

        // Assert
        session.LastInteractionAt.ShouldBeGreaterThanOrEqualTo(previousInteraction);
    }

    [Fact]
    public void GetContextData_WithNonExistentKey_ShouldReturnNull()
    {
        // Arrange
        var session = _faker.CreateValidSession();

        // Act
        var result = session.GetContextData(_faker.ContextKey);

        // Assert
        result.ShouldBeNull();
    }

    [Fact]
    public void AddContextData_MultipleKeys_ShouldStoreAll()
    {
        // Arrange
        var session = _faker.CreateValidSession();
        const string keyCpf = "cpf";
        var valueCpf = _faker.ContextValue;
        const string keyProtocol = "protocol";
        var valueProtocol = _faker.ContextValue;
        const string keyName = "name";
        var valueName = _faker.ContextValue;

        // Act
        session.AddContextData(keyCpf, valueCpf);
        session.AddContextData(keyProtocol, valueProtocol);
        session.AddContextData(keyName, valueName);

        // Assert
        session.ContextData.Count.ShouldBe(3);
        session.GetContextData(keyCpf).ShouldBe(valueCpf);
        session.GetContextData(keyProtocol).ShouldBe(valueProtocol);
        session.GetContextData(keyName).ShouldBe(valueName);
    }

    #endregion

    #region CheckExpiration

    [Fact]
    public void CheckExpiration_WhenWithinTimeout_ShouldReturnFalseAndRemainActive()
    {
        // Arrange
        var session = _faker.CreateValidSession();

        // Act — session was just created, so timeout of 30 min should not trigger
        var expired = session.CheckExpiration(timeoutInMinutes: 30);

        // Assert
        expired.ShouldBeFalse();
        session.IsActive.ShouldBeTrue();
    }

    [Fact]
    public void CheckExpiration_WhenExceedsTimeout_ShouldReturnTrueAndDeactivate()
    {
        // Arrange
        var session = _faker.CreateValidSession();

        // Act — using negative timeout to guarantee expiration
        var expired = session.CheckExpiration(timeoutInMinutes: -1);

        // Assert
        expired.ShouldBeTrue();
        session.IsActive.ShouldBeFalse();
    }

    [Fact]
    public void CheckExpiration_CalledTwice_ShouldStayInactive()
    {
        // Arrange
        var session = _faker.CreateValidSession();
        session.CheckExpiration(timeoutInMinutes: -1);

        // Act
        var expiredAgain = session.CheckExpiration(timeoutInMinutes: -1);

        // Assert
        expiredAgain.ShouldBeTrue();
        session.IsActive.ShouldBeFalse();
    }

    #endregion
}