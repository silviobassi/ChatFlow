namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

public sealed record DocumentContent(
    string Filename,
    DocumentMedia Media,
    string? Caption = null
);