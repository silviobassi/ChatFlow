﻿using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Buttons;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Footers;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Headers;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Nodes;

namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Builders;

public sealed class ResponseButtonNodeBuilder
{
    private string _nodeId = string.Empty;
    private string _name = string.Empty;
    private string _messageText = string.Empty;
    private readonly List<ButtonReply> _buttonReplies = [];
    private Header? _header;
    private FooterText? _footerText;

    public ResponseButtonNodeBuilder WithNodeId(string nodeId)
    {
        _nodeId = nodeId;
        return this;
    }

    public ResponseButtonNodeBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ResponseButtonNodeBuilder WithMessageText(string messageText)
    {
        _messageText = messageText;
        return this;
    }

    public ResponseButtonNodeBuilder AddButtonReply(ButtonReply buttonReply)
    {
        _buttonReplies.Add(buttonReply);
        return this;
    }

    public ResponseButtonNodeBuilder WithHeader(Header header)
    {
        _header = header;
        return this;
    }

    public ResponseButtonNodeBuilder WithFooterText(FooterText footerText)
    {
        _footerText = footerText;
        return this;
    }

    public ResponseButtonNode Build() => new(_nodeId, _name, _messageText, _buttonReplies, _header, _footerText);
}

