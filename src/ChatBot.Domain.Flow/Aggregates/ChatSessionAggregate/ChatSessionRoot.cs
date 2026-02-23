namespace ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate;

/// <summary>
/// Aggregate root representing an active chat session between a user and the bot.
/// Tracks the user's current position within the conversation flow, stores contextual data
/// collected during the interaction (e.g., CPF, protocol number, name), and enforces
/// session lifecycle rules such as expiration via timeout.
/// </summary>
public sealed class ChatSessionRoot
{
    /// <summary>Unique identifier for this chat session.</summary>
    public Guid Id { get; private set; }

    /// <summary>Phone number of the user engaged in this session.</summary>
    public string UserPhoneNumber { get; private set; }

    /// <summary>Identifier of the conversation node the user is currently on.</summary>
    public string CurrentNodeId { get; private set; }

    /// <summary>Identifier of the conversation flow the user is currently in.</summary>
    public string CurrentFlowId { get; private set; }

    // Session time-tracking for expiration control
    /// <summary>UTC timestamp of when the session was created.</summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>UTC timestamp of the last user interaction within the session.</summary>
    public DateTime LastInteractionAt { get; private set; }

    /// <summary>Indicates whether the session is still active.</summary>
    public bool IsActive { get; private set; }

    /// <summary>Identifier of the tenant this session belongs to.</summary>
    public long TenantId { get; private set; }

    /// <summary>
    /// Factory method that creates a new active chat session.
    /// </summary>
    /// <param name="tenantId">Positive identifier of the tenant.</param>
    /// <param name="userPhoneNumber">Phone number of the user starting the session.</param>
    /// <param name="startNodeId">Identifier of the initial conversation node.</param>
    /// <param name="startFlowId">Identifier of the initial conversation flow.</param>
    /// <returns>A new <see cref="ChatSessionRoot"/> instance.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when <paramref name="tenantId"/> is not positive, or any string parameter is null or empty.
    /// </exception>
    public static ChatSessionRoot CreateSession(long tenantId, string userPhoneNumber, string startNodeId,
        string startFlowId)
        => new(tenantId, userPhoneNumber, startNodeId, startFlowId);

    private ChatSessionRoot(long tenantId, string userPhoneNumber, string startNodeId, string startFlowId)
    {
        if (tenantId <= 0) throw new InvalidOperationException("O tenant ID deve ser um número positivo.");

        // Basic phone-number validation
        if (string.IsNullOrEmpty(userPhoneNumber))
            throw new InvalidOperationException("O número de telefone do usuário não pode ser nulo ou vazio.");
        if (string.IsNullOrEmpty(startNodeId))
            throw new InvalidOperationException("O ID do nó inicial não pode ser nulo ou vazio.");
        if (string.IsNullOrEmpty(startFlowId))
            throw new InvalidOperationException("O ID do fluxo inicial não pode ser nulo ou vazio.");


        Id = Guid.NewGuid();
        UserPhoneNumber = userPhoneNumber;
        CurrentNodeId = startNodeId;
        CurrentFlowId = startFlowId;
        TenantId = tenantId;
        CreatedAt = DateTime.UtcNow;
        LastInteractionAt = DateTime.UtcNow;
        IsActive = true;
    }

    // A "Memória" do Bot. Guarda, dados capturados (CPF, Protocolo, Nome)
    private readonly Dictionary<string, string> _contextData = new();
    public IReadOnlyDictionary<string, string> ContextData => _contextData;

    /// <summary>
    /// Transitions the user to a different node within the current flow and refreshes the interaction timestamp.
    /// </summary>
    /// <param name="nextNodeId">Identifier of the target node.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when <paramref name="nextNodeId"/> is null/empty or the session is inactive.
    /// </exception>
    public void TransitionToNode(string nextNodeId)
    {
        if (string.IsNullOrEmpty(nextNodeId))
            throw new InvalidOperationException("O ID do próximo nó não pode ser nulo ou vazio.");
        if (!IsActive) throw new InvalidOperationException("Sessão inativa.");

        CurrentNodeId = nextNodeId;
        LastInteractionAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Performs a flow jump — transitions the user to the start node of a different flow
    /// and refreshes the interaction timestamp.
    /// </summary>
    /// <param name="nextFlowId">Identifier of the target flow.</param>
    /// <param name="startNodeId">Identifier of the entry node in the target flow.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when <paramref name="nextFlowId"/> is null/empty or the session is inactive.
    /// </exception>
    public void TransitionToFlow(string nextFlowId, string startNodeId)
    {
        if (string.IsNullOrEmpty(nextFlowId))
            throw new InvalidOperationException("O ID do próximo fluxo não pode ser nulo ou vazio.");
        if (!IsActive) throw new InvalidOperationException("Sessão inativa.");

        CurrentFlowId = nextFlowId;
        CurrentNodeId = startNodeId;
        LastInteractionAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Stores or updates a key-value pair in the session's context data and refreshes the interaction timestamp.
    /// If the key already exists its value is overwritten.
    /// </summary>
    /// <param name="key">Context data key (e.g., "cpf", "protocol").</param>
    /// <param name="value">Value to associate with the key.</param>
    public void AddContextData(string key, string value)
    {
        _contextData[key] = value; // Overwrites if key already exists

        LastInteractionAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Retrieves a previously stored context value by its key.
    /// </summary>
    /// <param name="key">The key to look up.</param>
    /// <returns>The associated value, or <c>null</c> if the key does not exist.</returns>
    public string? GetContextData(string key) => _contextData.GetValueOrDefault(key);

    /// <summary>
    /// Checks whether the session has expired based on the elapsed time since the last interaction.
    /// If the timeout threshold is exceeded the session is automatically deactivated.
    /// </summary>
    /// <param name="timeoutInMinutes">Maximum allowed idle time in minutes.</param>
    /// <returns>
    /// <c>true</c> if the session has expired and was deactivated; <c>false</c> if still valid.
    /// </returns>
    public bool CheckExpiration(int timeoutInMinutes)
    {
        var timeSinceLastInteraction = DateTime.UtcNow - LastInteractionAt;
        if (timeSinceLastInteraction.TotalMinutes <= timeoutInMinutes) return false; // Still valid
        IsActive = false;
        return true; // Expired
    }
}