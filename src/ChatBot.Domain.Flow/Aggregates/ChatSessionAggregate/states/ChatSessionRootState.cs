using ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate.Events;
using ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate.states;

internal sealed class ChatSessionRootState
{
    internal int Version { get; private set; } = -1;

    // Se o flow engine transbordar pra humano, o current node é atualizado para transbordo.
    internal CurrentNode CurrentNode { get; private set; }
    internal ConversationActor ConversationActor { get; private set; } = null!;
    internal MessageText MessageText { get; private set; }
    internal DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    internal DateTime LastInteractionAt { get; private set; } = DateTime.UtcNow;

    internal bool IsActive { get; private set; }
    
    internal void Apply(MessageSent @event){}
    
    internal void Apply(MessageReceived @event){}
}