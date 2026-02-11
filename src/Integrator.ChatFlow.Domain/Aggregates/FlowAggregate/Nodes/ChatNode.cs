using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Options;

namespace Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;

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

// Value Object para o nome do contato

// Value Object para o telefone do contato

// Value Object para subdivisões de botões (seção + linhas)

// Value Object para as linhas numa seção de botões

// create node for TextOption
// I'm implementing this for MessageAdapter