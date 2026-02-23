using ChatBot.Domain.Flow.Aggregates.ChatConversationAggregate.Events;

namespace ChatBot.Domain.Flow.Aggregates.ChatConversationAggregate;

public abstract class AbstractLoader
{
    protected abstract void When(IDomainEvent @event);
    protected abstract void LoadFromHistory(IEnumerable<IDomainEvent> @events);
}