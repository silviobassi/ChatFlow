namespace Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.ValuesObject;

public record struct DocumentContent(
    string Filename,
    string? DocumentUrl = null,
    string? Caption = null
);