using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Nodes;

namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate;

public sealed record FlowEngineRoot(
    string Id,          // Identificador do Fluxo (ex: "onboarding_v1")
    string Name,        // Nome legível (ex: "Fluxo de Onboarding 2026")
    // criar propriedade para mapear campanhas ADS
    string TriggerKeyword, // Palavra-chave que inicia este fluxo (ex: "oi", "menu")
    bool IsActive, 
    int CampaignId,
    long TenantId,
    long ConfigurationId
)
{
    // A lista de nós, agora vive DENTRO do fluxo
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
    public void RemoveNode(string nodeId)
    {
        var node = _nodes.FirstOrDefault(n => n.NodeId == nodeId);
        if (node == null)
        {
            throw new InvalidOperationException($"O nó '{nodeId}' não existe neste fluxo.");
        }
        _nodes.Remove(node);
    }
}