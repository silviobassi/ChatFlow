namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

public sealed record DocumentId : DocumentMedia
{
    public DocumentId(string Value) : base(Value)
    {
        if (string.IsNullOrWhiteSpace(Value) || !Value.All(char.IsDigit))
        {
            throw new InvalidOperationException(
                $"🦀 O ID '{Value}' não é válido. Informe um ID numérico válido (ex: 106540352242922).");
        }
    }

    public static implicit operator string(DocumentId documentId) => documentId.Value;
}