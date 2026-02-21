namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Buttons;

public sealed record ListButtonConfig(ButtonText ButtonText, List<SectionButton> SubdivisionsButtons);