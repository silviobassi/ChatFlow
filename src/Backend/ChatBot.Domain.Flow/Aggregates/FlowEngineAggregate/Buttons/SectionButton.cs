namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Buttons;

public sealed record SectionButton(string Title)
{
    public List<RowListButton> Rows { get; } = [];

    public void AddRow(RowListButton row) => Rows.Add(row);
}

// Validar se, nas seções, tem dois botöes com ids duplicados, ou seja, com o mesmo id, independente da seção.
// Validar se, nas seções, tem dois TargetNode ou TargetFlow com o mesmo id, independente da seção.