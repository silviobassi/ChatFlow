using ChatBot.Domain.Flow.Aggregates.FlowAggregate;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Repositories;
using MongoDB.Driver;

namespace ChatBot.Modules.Flow.Features.CreateFlow;

public class ChatFlowRepository(IMongoDatabase database) : IChatFlowRepository
{
    private readonly IMongoCollection<ChatFlowRoot> _collection = database.GetCollection<ChatFlowRoot>("Flows");

    // Salva o fluxo inteiro (com todos os nós dentro)
    public async Task SaveAsync(ChatFlowRoot flow)
    {
        var flowExists = await _collection.Find(x => x.Id == flow.Id).AnyAsync();

        if (flowExists) throw new InvalidOperationException($"❌ Fluxo '{flow.Id}' já existe.");

        await _collection.InsertOneAsync(flow);
    }

    public async Task UpdateAsync(ChatFlowRoot flow)
    {
        var filter = Builders<ChatFlowRoot>.Filter.Eq(x => x.Id, flow.Id);
        var result = await _collection.ReplaceOneAsync(filter, flow);

        if (result.MatchedCount == 0)
            throw new InvalidOperationException($"❌ Fluxo '{flow.Id}' não encontrado para atualização.");
    }

    public async Task<ChatFlowRoot?> GetFlowByIdAsync(string flowId)
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