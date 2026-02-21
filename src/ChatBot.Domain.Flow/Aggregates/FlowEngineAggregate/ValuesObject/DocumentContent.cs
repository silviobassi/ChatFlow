namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.ValuesObject;

public sealed record DocumentContent(
    string Filename,
    DocumentMedia Media,
    string? Caption = null
);