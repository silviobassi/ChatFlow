using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Buttons;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Footers;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Headers;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Nodes;

namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Builders;

public sealed class ListButtonNodeBuilder
{
    private string _nodeId = string.Empty;
    private string _name = string.Empty;
    private string _messageText = string.Empty;
    private ButtonText _buttonText;
    private readonly List<SectionButton> _sectionsButtons = [];
    private FooterText? _footerText;
    private HeaderText? _headerText;

    public ListButtonNodeBuilder WithNodeId(string nodeId)
    {
        _nodeId = nodeId;
        return this;
    }

    public ListButtonNodeBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ListButtonNodeBuilder WithMessageText(string messageText)
    {
        _messageText = messageText;
        return this;
    }

    public ListButtonNodeBuilder WithButtonText(ButtonText buttonText)
    {
        _buttonText = buttonText;
        return this;
    }

    public ListButtonNodeBuilder AddSectionButton(SectionButton sectionButton)
    {
        _sectionsButtons.Add(sectionButton);
        return this;
    }

    public ListButtonNodeBuilder WithFooterText(FooterText footerText)
    {
        _footerText = footerText;
        return this;
    }

    public ListButtonNodeBuilder WithHeaderText(HeaderText headerText)
    {
        _headerText = headerText;
        return this;
    }

    public ListButtonNode Build() => new(_nodeId, _name, _messageText, _buttonText, _sectionsButtons, _footerText, _headerText);
}

