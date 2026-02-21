namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Headers;

public record HeaderImageUrl(string Value) : Header(Value, "image");