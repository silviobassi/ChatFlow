namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Headers;

public sealed record HeaderImageId(string Value) : Header(Value, "image");