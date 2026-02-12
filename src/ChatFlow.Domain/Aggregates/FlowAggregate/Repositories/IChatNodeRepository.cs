using ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;

namespace ChatFlow.Domain.Aggregates.FlowAggregate.Repositories;

public interface IChatNodeRepository
{
    Task AddNodeAsync(string flowId, ChatNode newNode);
}