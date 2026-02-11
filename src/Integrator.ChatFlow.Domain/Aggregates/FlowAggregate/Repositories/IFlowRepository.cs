using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;

namespace Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Repositories;

public interface IFlowRepository
{
    Task<ChatNode> GetByIdAsync(string nodeId);
    
    Task SaveAsync(ChatNode node);
}