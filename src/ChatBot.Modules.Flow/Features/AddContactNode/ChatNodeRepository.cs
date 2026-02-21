using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Nodes;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Repositories;
using MongoDB.Driver;

namespace ChatBot.Modules.Flow.Features.AddContactNode;

public class ChatNodeRepository(IMongoDatabase database) : IChatNodeRepository
{
    private readonly IMongoCollection<FlowEngineRoot> _collection = database.GetCollection<FlowEngineRoot>("Flows");

    private UpdateResult? _updateResult;

    public async Task AddNodeAsync(string flowId, ChatNode newNode)
    {
        var filter = GetFlowId(flowId, newNode);

        var update = PushNode(newNode);

        _updateResult = await _collection.UpdateOneAsync(filter, update);

        await CheckFlow(flowId, newNode);
    }


    private static FilterDefinition<FlowEngineRoot> GetFlowId(string flowId, ChatNode newNode)
    {
        var filter = Builders<FlowEngineRoot>.Filter.And(
            Builders<FlowEngineRoot>.Filter.Eq(x => x.Id, flowId),
            IsNodeDuplicate(newNode) // "Ne" = Not Equal
        );
        return filter;
    }

    private static FilterDefinition<FlowEngineRoot> IsNodeDuplicate(ChatNode newNode)
    {
        return Builders<FlowEngineRoot>.Filter.Ne("Nodes.NodeId", newNode.NodeId);
    }

    private static UpdateDefinition<FlowEngineRoot> PushNode(ChatNode newNode)
    {
        var update = Builders<FlowEngineRoot>.Update.Push("Nodes", newNode);
        return update;
    }

    private async Task CheckFlow(string flowId, ChatNode newNode)
    {
        if (_updateResult?.MatchedCount == 0)
        {
            var flowExists = await FlowExists(flowId);

            if (!flowExists)
                throw new InvalidOperationException($"❌ Fluxo '{flowId}' não encontrado.");

            throw new InvalidOperationException($"❌ O nó '{newNode.NodeId}' já existe neste fluxo.");
        }
    }

    private async Task<bool> FlowExists(string flowId)
    {
        var flowExists = await _collection
            .Find(x => x.Id == flowId)
            .AnyAsync();
        return flowExists;
    }
}