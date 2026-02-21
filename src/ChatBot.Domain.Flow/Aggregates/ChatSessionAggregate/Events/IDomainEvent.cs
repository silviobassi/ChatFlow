namespace ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate.Events;

public interface IDomainEvent
{
    public DateTime OccurredOn { get; }
}