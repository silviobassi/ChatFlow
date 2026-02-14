namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

public readonly record struct ContactName(
    string FormattedName,
    string? FirstName = null,
    string? LastName = null
);