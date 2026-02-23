namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Headers;

public abstract record Header(string Value, string Type)
{
    public string Type { get; } = Type;
}