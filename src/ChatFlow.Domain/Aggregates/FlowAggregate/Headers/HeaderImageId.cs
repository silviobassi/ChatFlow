namespace ChatFlow.Domain.Aggregates.FlowAggregate.Headers;

public record HeaderImageId(string Value) : Header(Value)
{
    public override string Type { get; init; } = "image";
}