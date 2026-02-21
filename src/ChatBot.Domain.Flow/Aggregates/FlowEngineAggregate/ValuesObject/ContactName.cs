namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.ValuesObject;

public sealed record ContactName(string FormattedName, string? FirstName = null, string? LastName = null);