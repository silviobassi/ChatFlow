using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Nodes;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Builders;

public readonly record struct ContactNodeBuilder
{
    private string NodeId { get; init; }
    private string Name { get; init; }
    private string MessageText { get; init; }
    private ContactName ContactName { get; init; }
    private List<ContactPhone> Phones { get; init; }
    private TargetNode? TargetNode { get; init; }
    private TargetFlow? TargetFlow { get; init; }

    private ContactNodeBuilder(string nodeId, string name, string messageText, ContactName contactName)
    {
        NodeId = nodeId;
        Name = name;
        MessageText = messageText;
        ContactName = contactName;
        Phones = [];
        TargetNode = null;
        TargetFlow = null;
    }

    public static ContactNodeBuilder Builder(string nodeId, string name, string messageText, ContactName contactName)
        => new(nodeId, name, messageText, contactName);

    public ContactNodeBuilder WithPhone(ContactPhone phone)
    {
        var updatedPhones = new List<ContactPhone>(Phones) { phone };
        return this with { Phones = updatedPhones };
    }

    public ContactNodeBuilder WithPhones(IEnumerable<ContactPhone> phones)
    {
        var updatedPhones = new List<ContactPhone>(Phones);
        updatedPhones.AddRange(phones);
        return this with { Phones = updatedPhones };
    }

    public ContactNodeBuilder WithTargetNode(TargetNode targetNode)
    {
        return this with
        {
            TargetNode = targetNode, 
            TargetFlow = null
        };
    }

    public ContactNodeBuilder WithTargetFlow(TargetFlow targetFlow)
    {
        return this with
        {
            TargetFlow = targetFlow, 
            TargetNode = null
        };
    }

    public ContactNode Build()
    {
        if (string.IsNullOrWhiteSpace(NodeId))
            throw new InvalidOperationException("O NodeId é obrigatório.");

        if (string.IsNullOrWhiteSpace(Name))
            throw new InvalidOperationException("O Name é obrigatório.");

        if (string.IsNullOrWhiteSpace(MessageText))
            throw new InvalidOperationException("O MessageText é obrigatório.");

        if (string.IsNullOrWhiteSpace(ContactName.FormattedName))
            throw new InvalidOperationException("O FormattedName do contato é obrigatório.");

        if (Phones.Count == 0)
            throw new InvalidOperationException("É obrigatório informar ao menos um telefone para o contato.");

        return new ContactNode(NodeId, Name, MessageText, ContactName, Phones, TargetNode, TargetFlow);
    }
}