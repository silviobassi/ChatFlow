namespace Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Footers;

public record struct FooterText(string Value)
{
    public static implicit operator string(FooterText footerText) => footerText.Value;
}