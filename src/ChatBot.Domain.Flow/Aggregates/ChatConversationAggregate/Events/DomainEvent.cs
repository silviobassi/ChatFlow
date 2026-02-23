namespace ChatBot.Domain.Flow.Aggregates.ChatConversationAggregate.Events;

public abstract record DomainEvent : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}