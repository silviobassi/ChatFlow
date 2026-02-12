namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Repositories;

public interface IChatFlowRepository
{
    Task SaveAsync(ChatFlowRoot flow);
    Task<ChatFlowRoot?> GetByIdAsync(string flowId);
    Task<ChatFlowRoot?> GetByTriggerAsync(string keyword);
    
}