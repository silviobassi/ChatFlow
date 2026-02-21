namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

public sealed record DocumentId(string Value) : DocumentMedia(Value)
{
    public static implicit operator string(DocumentId documentId) => documentId.Value;
}