using ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate.Events;
using ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate.states;
using ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate;

public sealed class ChatSessionRoot : AggregateRoot
{
    private readonly ChatSessionRootState _state = new();

    public SessionId SessionId { get; private set; }

    // Se o flow engine transbordar pra humano, o current node é atualizado para transbordo.
    public CurrentNode CurrentNode => _state.CurrentNode;
    public ConversationActor ConversationActor => _state.ConversationActor;
    public MessageText MessageText => _state.MessageText;
    public DateTime CreatedAt => _state.CreatedAt;
    public DateTime LastInteractionAt => _state.LastInteractionAt;

    public bool IsActive => _state.IsActive;

    /*
     * CREATE COMMANDS
     * - StartChatSessionCommand
     * - SendMessageCommand
     * - ReceiveMessageCommand
     * - TransferToHumanCommand
     * - EndChatSessionCommand
     */

    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case MessageSent e: _state.Apply(e); break;
            case MessageReceived e: _state.Apply(e); break;
            // ...
        }
    }
}