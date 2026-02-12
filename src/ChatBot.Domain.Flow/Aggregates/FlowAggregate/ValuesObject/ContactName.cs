namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

public record struct ContactName(
    string FormattedName,
    string? FirstName = null,
    string? LastName = null
);