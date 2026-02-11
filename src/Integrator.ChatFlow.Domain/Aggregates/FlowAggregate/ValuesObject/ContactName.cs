namespace Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.ValuesObject;

public record struct ContactName(
    string FormattedName,
    string? FirstName = null,
    string? LastName = null
);