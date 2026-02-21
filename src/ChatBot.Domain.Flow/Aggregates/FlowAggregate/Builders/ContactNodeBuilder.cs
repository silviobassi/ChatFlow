using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Nodes;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Builders;

public sealed class ContactNodeBuilder
{
    private string _nodeId = string.Empty;
    private string _name = string.Empty;
    private string _messageText = string.Empty;
    private ContactName _contactName = null!;
    private readonly List<ContactPhone> _phones = [];
    private TargetNode? _targetNode;
    private TargetFlow? _targetFlow;

    public ContactNodeBuilder WithNodeId(string nodeId)
    {
        _nodeId = nodeId;
        return this;
    }

    public ContactNodeBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ContactNodeBuilder WithMessageText(string messageText)
    {
        _messageText = messageText;
        return this;
    }

    public ContactNodeBuilder WithContactName(ContactName contactName)
    {
        _contactName = contactName;
        return this;
    }

    public ContactNodeBuilder AddPhone(ContactPhone phone)
    {
        _phones.Add(phone);
        return this;
    }

    public ContactNodeBuilder WithTargetNode(TargetNode targetNode)
    {
        _targetFlow = null; // Garantir que apenas um dos destinos seja definido
        _targetNode = targetNode;
        return this;
    }

    public ContactNodeBuilder WithTargetFlow(TargetFlow targetFlow)
    {
        _targetNode = null; // Garantir que apenas um dos destinos seja definido
        _targetFlow = targetFlow;
        return this;
    }

    public ContactNode Build() => new(_nodeId, _name, _messageText, _contactName, _phones, _targetNode, _targetFlow);
}