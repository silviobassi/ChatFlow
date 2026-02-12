namespace ChatFlow.Domain.Aggregates.FlowAggregate.Headers;

public sealed record HeaderImageUrl(string Value) : Header(Value)
{
    public override string Type { get; init; } = "image";
}