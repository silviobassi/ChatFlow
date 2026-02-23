using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Nodes;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Builders;

public sealed class DocumentNodeBuilder
{
    private string _nodeId = string.Empty;
    private string _name = string.Empty;
    private string _messageText = string.Empty;
    private DocumentContent _documentContent = null!;
    private TargetNode? _targetNode;
    private TargetFlow? _targetFlow;

    public DocumentNodeBuilder WithNodeId(string nodeId)
    {
        _nodeId = nodeId;
        return this;
    }

    public DocumentNodeBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public DocumentNodeBuilder WithMessageText(string messageText)
    {
        _messageText = messageText;
        return this;
    }

    public DocumentNodeBuilder WithDocumentContent(DocumentContent documentContent)
    {
        _documentContent = documentContent;
        return this;
    }

    public DocumentNodeBuilder WithTargetNode(TargetNode targetNode)
    {
        _targetFlow = null; // Garantir que apenas um dos destinos seja definido
        _targetNode = targetNode;
        return this;
    }

    public DocumentNodeBuilder WithTargetFlow(TargetFlow targetFlow)
    {
        _targetNode = null; // Garantir que apenas um dos destinos seja definido
        _targetFlow = targetFlow;
        return this;
    }

    public DocumentNode Build() => new(_nodeId, _name, _messageText, _documentContent, _targetNode, _targetFlow);
}