using ChatBot.Domain.Flow.Aggregates.ChatConversationAggregate.Events;

namespace ChatBot.Domain.Flow.Aggregates.ChatConversationAggregate;

public abstract class AggregateRoot : AbstractLoader
{
    private readonly List<IDomainEvent> _uncommitedEvents = [];

    public IReadOnlyCollection<IDomainEvent> UncommitedEvents => _uncommitedEvents.AsReadOnly();

    protected void AppendEvent(IDomainEvent @event)
    {
        // Apply the event to the aggregate's state.
        When(@event);

        // Add the event to the list of uncommitted events.
        _uncommitedEvents.Add(@event);
    }

    protected void MarkEventsAsCommitted() => _uncommitedEvents.Clear();

    protected override void LoadFromHistory(IEnumerable<IDomainEvent> events)
    {
        foreach (var e in events) AppendEvent(e);
    }
}