namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Nodes;

public abstract record ChatNode(
    string NodeId, // E.g., opcoes_suporte
    string Name, // E.g., "Suporte Técnico"
    string MessageText // E.g., "Olá! Bem-vindo ao suporte técnico. Como posso ajudar você hoje?" — Mensagem principal (usada no body)
);

// Validar se for o último nó, redireciona para o fluxo de atendimento humano, ou retorna para o menu inicial. Enfim, quem criar o fluxo
// o fará seguindo sua própria lógica de negócio. Ele pode optar por encerrar o fluxo apenas com uma mensagem. A partir daí, o cliente
// pode recomeçar a conversa digitando um "oi, …" ou algo do tipo.