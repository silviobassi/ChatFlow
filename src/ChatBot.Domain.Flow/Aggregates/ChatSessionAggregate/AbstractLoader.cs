using ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate.Events;

namespace ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate;

public abstract class AbstractLoader
{
    protected abstract void When(IDomainEvent @event);
    protected abstract void LoadFromHistory(IEnumerable<IDomainEvent> @events);
}