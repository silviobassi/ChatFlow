namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.ValuesObject;

public sealed record ContactPhone(
    // For meta, this is not required, but self business rules require it, so we keep it as required
    string WaId,
    string? Phone = null,
    string? Type = null
);