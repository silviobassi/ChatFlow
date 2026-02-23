namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Footers;

public readonly record struct FooterText(string Value)
{
    public static implicit operator string(FooterText footerText) => footerText.Value;
}