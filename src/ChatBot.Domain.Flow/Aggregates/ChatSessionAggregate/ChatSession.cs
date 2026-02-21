namespace ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate;

public sealed class ChatSession
{
    public long SessionId {get; private set;}
    public string CurrentNode { get; private set; }
    public string TenantCellPhone { get; private set; }
    public string CustomerCellPhone { get; private set; }
    public string MessageText { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime LastInteractionAt { get; private set; } = DateTime.UtcNow;
}