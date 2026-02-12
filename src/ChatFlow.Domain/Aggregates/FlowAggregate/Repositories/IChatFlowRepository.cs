namespace ChatFlow.Domain.Aggregates.FlowAggregate.Repositories;

public interface IChatFlowRepository
{
    Task SaveAsync(ChatFlowRoot flow);
    Task<ChatFlowRoot?> GetByIdAsync(string flowId);
    Task<ChatFlowRoot?> GetByTriggerAsync(string keyword);
    
}