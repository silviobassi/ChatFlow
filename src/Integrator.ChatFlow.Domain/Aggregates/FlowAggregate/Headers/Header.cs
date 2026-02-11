namespace Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Headers;

public abstract record Header(string Value)
{
    public abstract string Type { get; init; }
}