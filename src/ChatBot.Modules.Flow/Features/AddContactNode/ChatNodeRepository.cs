using ChatBot.Domain.Flow.Aggregates.FlowAggregate;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Nodes;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Repositories;
using MongoDB.Driver;

namespace ChatBot.Modules.Flow.Features.AddContactNode;

public class ChatNodeRepository(IMongoDatabase database) : IChatNodeRepository
{
    private readonly IMongoCollection<ChatFlowRoot> _collection = database.GetCollection<ChatFlowRoot>("Flows");

    private UpdateResult? _updateResult;

    public async Task AddNodeAsync(string flowId, ChatNode newNode)
    {
        var filter = GetFlowId(flowId, newNode);

        var update = PushNode(newNode);

        _updateResult = await _collection.UpdateOneAsync(filter, update);

        await CheckFlow(flowId, newNode);
    }


    private static FilterDefinition<ChatFlowRoot> GetFlowId(string flowId, ChatNode newNode)
    {
        var filter = Builders<ChatFlowRoot>.Filter.And(
            Builders<ChatFlowRoot>.Filter.Eq(x => x.Id, flowId),
            IsNodeDuplicate(newNode) // "Ne" = Not Equal
        );
        return filter;
    }

    private static FilterDefinition<ChatFlowRoot> IsNodeDuplicate(ChatNode newNode)
    {
        return Builders<ChatFlowRoot>.Filter.Ne("Nodes.NodeId", newNode.NodeId);
    }

    private static UpdateDefinition<ChatFlowRoot> PushNode(ChatNode newNode)
    {
        var update = Builders<ChatFlowRoot>.Update.Push("Nodes", newNode);
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