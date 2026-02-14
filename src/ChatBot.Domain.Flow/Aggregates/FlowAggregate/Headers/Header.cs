namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Headers;

public abstract record Header(string Value, string Type)
{
    public string Type { get; } = Type;
}