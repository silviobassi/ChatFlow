using ChatFlow.Domain.Aggregates.FlowAggregate;
using ChatFlow.Domain.Aggregates.FlowAggregate.Repositories;
using MongoDB.Driver;

namespace ChatFlow.Modules.Nodes.Features.FlowCreate;

public class ChatFlowRepository(IMongoDatabase database) : IChatFlowRepository
{
    private readonly IMongoCollection<ChatFlowRoot> _collection = database.GetCollection<ChatFlowRoot>("Flows");

    // Salva o fluxo inteiro (com todos os nós dentro)
    public async Task SaveAsync(ChatFlowRoot flow)
    {
        var filter = Builders<ChatFlowRoot>.Filter.Eq(x => x.Id, flow.Id);

        await _collection.ReplaceOneAsync(
            filter,
            flow,
            new ReplaceOptions { IsUpsert = true }
        );
    }

    public async Task<ChatFlowRoot?> GetByIdAsync(string flowId)
    {
        return await _collection.Find(x => x.Id == flowId).FirstOrDefaultAsync();
    }

    public async Task<ChatFlowRoot?> GetByTriggerAsync(string keyword)
    {
        var filter = Builders<ChatFlowRoot>.Filter.And(
            Builders<ChatFlowRoot>.Filter.Eq(x => x.IsActive, true),
            Builders<ChatFlowRoot>.Filter.Eq(x => x.TriggerKeyword, keyword)
        );

        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
}