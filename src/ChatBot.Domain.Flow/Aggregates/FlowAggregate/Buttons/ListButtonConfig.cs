namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Buttons;

public record struct ListButtonConfig(ButtonText ButtonText, List<SectionButton> SubdivisionsButtons);