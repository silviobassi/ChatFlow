namespace ChatBot.Domain.Flow.Aggregates.ChatConversationAggregate.Events;

public interface IDomainEvent
{
    public DateTime OccurredOn { get; }
}