using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Nodes;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Builders;

public readonly record struct DocumentNodeBuilder
{
    private string NodeId { get; init; }
    private string Name { get; init; }
    private string MessageText { get; init; }
    private string Filename { get; init; }
    private DocumentMedia? Media { get; init; }
    private string? Caption { get; init; }
    private TargetNode? TargetNode { get; init; }
    private TargetFlow? TargetFlow { get; init; }

    private DocumentNodeBuilder(string nodeId, string name, string messageText, string filename)
    {
        NodeId = nodeId;
        Name = name;
        MessageText = messageText;
        Filename = filename;
        Media = null;
        Caption = null;
        TargetNode = null;
        TargetFlow = null;
    }

    public static DocumentNodeBuilder Builder(string nodeId, string name, string messageText, string filename)
        => new(nodeId, name, messageText, filename);

    public DocumentNodeBuilder WithDocumentId(string documentId)
    {
        return this with { Media = new DocumentId(documentId) };
    }

    public DocumentNodeBuilder WithDocumentLink(string documentLink)
    {
        return this with { Media = new DocumentLink(documentLink) };
    }

    public DocumentNodeBuilder WithCaption(string caption)
    {
        return this with { Caption = caption };
    }

    public DocumentNodeBuilder WithTargetNode(TargetNode targetNode)
    {
        return this with
        {
            TargetNode = targetNode,
            TargetFlow = null
        };
    }

    public DocumentNodeBuilder WithTargetFlow(TargetFlow targetFlow)
    {
        return this with
        {
            TargetNode = null,
            TargetFlow = targetFlow
        };
    }

    public DocumentNode Build()
    {
        if (string.IsNullOrWhiteSpace(NodeId))
            throw new InvalidOperationException("O NodeId é obrigatório.");

        if (string.IsNullOrWhiteSpace(Name))
            throw new InvalidOperationException("O Name é obrigatório.");

        if (string.IsNullOrWhiteSpace(MessageText))
            throw new InvalidOperationException("O MessageText é obrigatório.");

        if (string.IsNullOrWhiteSpace(Filename))
            throw new InvalidOperationException("O Filename é obrigatório.");

        if (Media is null)
            throw new InvalidOperationException("É obrigatório informar DocumentId ou DocumentLink.");

        var documentContent = new DocumentContent(Filename, Media, Caption);

        return new DocumentNode(NodeId, Name, MessageText, documentContent, TargetNode, TargetFlow);
    }
}