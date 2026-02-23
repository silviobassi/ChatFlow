using Bogus;
using ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate;

namespace ChatBot.CommonUtils.Tests.Fakers;

/// <summary>
/// Provides fake data generation for <see cref="ChatSessionRoot"/> test scenarios
/// using the Bogus library.
/// </summary>
public sealed class ChatSessionRootFaker
{
    private readonly Faker _faker = new("pt_BR");

    public long TenantId => _faker.Random.Long(1, 10_000);
    public string PhoneNumber => _faker.Phone.PhoneNumber("55##9########");
    public string NodeId => _faker.Random.AlphaNumeric(10);
    public string FlowId => _faker.Random.AlphaNumeric(10);
    public string ContextKey => _faker.Lorem.Word();
    public string ContextValue => _faker.Lorem.Sentence();

    /// <summary>
    /// Creates a valid <see cref="ChatSessionRoot"/> with randomized data.
    /// </summary>
    public ChatSessionRoot CreateValidSession()
        => ChatSessionRoot.CreateSession(TenantId, PhoneNumber, NodeId, FlowId);

    /// <summary>
    /// Creates a <see cref="ChatSessionRoot"/> allowing explicit overrides for each parameter.
    /// Unspecified parameters default to randomized fake values.
    /// Pass <c>null</c> or empty explicitly to test validation.
    /// </summary>
    public ChatSessionRoot CreateSession(
        long? tenantId = null,
        Optional<string> phoneNumber = default,
        Optional<string> startNodeId = default,
        Optional<string> startFlowId = default)
        => ChatSessionRoot.CreateSession(
            tenantId ?? TenantId,
            phoneNumber.HasValue ? phoneNumber.Value : PhoneNumber,
            startNodeId.HasValue ? startNodeId.Value : NodeId,
            startFlowId.HasValue ? startFlowId.Value : FlowId);
}

/// <summary>
/// Lightweight optional wrapper to distinguish "not provided" from "explicitly null".
/// </summary>
public readonly struct Optional<T>
{
    public bool HasValue { get; }
    public T Value { get; }

    private Optional(T value)
    {
        HasValue = true;
        Value = value;
    }

    public static implicit operator Optional<T>(T value) => new(value);
}

