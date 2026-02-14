using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Nodes;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Builders;

public readonly record struct TextNodeBuilder
{
    private string NodeId { get; init; }
    private string Name { get; init; }
    private string MessageText { get; init; }
    private TextContent TextContent { get; init; }
    private TargetNode? TargetNode { get; init; }
    private TargetFlow? TargetFlow { get; init; }

    private TextNodeBuilder(string nodeId, string name, string messageText)
    {
        NodeId = nodeId;
        Name = name;
        MessageText = messageText;
        TextContent = new TextContent();
        TargetNode = null;
        TargetFlow = null;
    }

    public static TextNodeBuilder Builder(string nodeId, string name, string messageText)
        => new(nodeId, name, messageText);

    public TextNodeBuilder WithPreviewUrl(bool previewUrl = true)
    {
        return this with { TextContent = new TextContent(previewUrl) };
    }

    public TextNodeBuilder WithTargetNode(TargetNode targetNode)
    {
        return this with
        {
            TargetNode = targetNode,
            TargetFlow = null
        };
    }

    public TextNodeBuilder WithTargetFlow(TargetFlow targetFlow)
    {
        return this with
        {
            TargetNode = null,
            TargetFlow = targetFlow
        };
    }

    public TextNode Build()
    {
        if (string.IsNullOrWhiteSpace(NodeId))
            throw new InvalidOperationException("O NodeId é obrigatório.");

        if (string.IsNullOrWhiteSpace(Name))
            throw new InvalidOperationException("O Name é obrigatório.");

        if (string.IsNullOrWhiteSpace(MessageText))
            throw new InvalidOperationException("O MessageText é obrigatório.");

        return new TextNode(NodeId, Name, MessageText, TextContent, TargetFlow, TargetNode);
    }
}