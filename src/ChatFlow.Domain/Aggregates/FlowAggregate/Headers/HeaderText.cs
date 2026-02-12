namespace ChatFlow.Domain.Aggregates.FlowAggregate.Headers;

public sealed record HeaderText(string Value) : Header(Value)
{
    public override string Type { get; init; } = "text";

    public static implicit operator string(HeaderText headerText) => headerText.Value;
}