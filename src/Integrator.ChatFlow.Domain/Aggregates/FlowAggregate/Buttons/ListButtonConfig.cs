namespace Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Buttons;

public record struct ListButtonConfig(ButtonText ButtonText, List<SectionButton> SubdivisionsButtons);