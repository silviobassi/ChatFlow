using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Nodes;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Repositories;

public interface IChatNodeRepository
{
    Task AddNodeAsync(string flowId, ChatNode newNode);
}