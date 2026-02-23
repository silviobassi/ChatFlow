namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Headers;

public sealed record HeaderText(string Value) : Header(Value, "text")
{
    public static implicit operator string(HeaderText headerText) => headerText.Value;
}