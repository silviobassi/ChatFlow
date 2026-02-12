using ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;

namespace ChatFlow.Domain.Aggregates.FlowAggregate;

public sealed record ChatFlowRoot(
    string Id,          // Identificador do Fluxo (ex: "onboarding_v1")
    string Name,        // Nome legível (ex: "Fluxo de Onboarding 2026")
    string TriggerKeyword, // Palavra-chave que inicia este fluxo (ex: "oi", "menu")
    bool IsActive
)
{
    // A lista de nós agora vive DENTRO do fluxo
    private readonly List<ChatNode> _nodes = [];
    
    public IReadOnlyCollection<ChatNode> Nodes => _nodes.AsReadOnly();

    // Método de Domínio para adicionar nós (garante integridade)
    public void AddNode(ChatNode node)
    {
        if (_nodes.Any(n => n.NodeId == node.NodeId))
        {
            throw new InvalidOperationException($"O nó '{node.NodeId}' já existe neste fluxo.");
        }
        _nodes.Add(node);
    }

    // Método para remover nós, etc...
}