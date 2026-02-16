namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

public sealed record ContactName(string FormattedName, string? FirstName = null, string? LastName = null);