using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Options;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Nodes;

public abstract record ChatNode(
    string NodeId, // E.g., opcoes_suporte
    string Name, // E.g., "Suporte Técnico"
    string MessageText // E.g., "Olá! Bem-vindo ao suporte técnico. Como posso ajudar você hoje?" — Mensagem principal (usada no body)
)
{
    // Lista de opções que o usuário pode escolher (Independente de ser Botão ou Lista)
    private readonly List<ChatOption> _options = [];

    public IReadOnlyCollection<ChatOption> Options => _options.AsReadOnly();

    public void AddOption(string id, string label, string nextNodeId) =>
        _options.Add(new ChatOption(id, label, nextNodeId));
}