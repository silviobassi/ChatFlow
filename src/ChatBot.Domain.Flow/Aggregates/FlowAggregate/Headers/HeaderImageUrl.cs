namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Headers;

public record HeaderImageUrl(string Value) : Header(Value, "image");