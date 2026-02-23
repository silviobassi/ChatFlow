namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Repositories;

public interface IChatFlowRepository
{
    Task SaveAsync(FlowEngineRoot flowEngine);
    Task<FlowEngineRoot?> GetFlowByIdAsync(string flowId);
    Task<FlowEngineRoot?> GetByTriggerAsync(string keyword);
    
}