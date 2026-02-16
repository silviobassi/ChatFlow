namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Buttons;

public sealed record SectionButton(string Title, List<RowListButton> Rows );

// Validar se, nas seções, tem dois botöes com ids duplicados, ou seja, com o mesmo id, independente da seção.
// Validar se, nas seções, tem dois TargetNode ou TargetFlow com o mesmo id, independente da seção.