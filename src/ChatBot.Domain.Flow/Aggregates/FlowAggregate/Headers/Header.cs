namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Headers;

public abstract record Header(string Value)
{
    public abstract string Type { get; init; }
}