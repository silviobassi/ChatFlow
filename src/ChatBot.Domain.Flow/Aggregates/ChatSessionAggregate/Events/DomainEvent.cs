namespace ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate.Events;

public abstract record DomainEvent : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}