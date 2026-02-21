namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Headers;

public sealed record HeaderImageId(string Value) : Header(Value, "image");