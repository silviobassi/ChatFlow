using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Nodes;

namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Repositories;

public interface IChatNodeRepository
{
    Task AddNodeAsync(string flowId, ChatNode newNode);
}