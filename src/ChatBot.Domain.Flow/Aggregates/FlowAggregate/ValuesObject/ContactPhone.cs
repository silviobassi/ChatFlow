namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

public readonly record struct ContactPhone(
    // For meta, this is not required, but self business rules require it, so we keep it as required
    string WaId,
    string? Phone = null,
    string? Type = null
);