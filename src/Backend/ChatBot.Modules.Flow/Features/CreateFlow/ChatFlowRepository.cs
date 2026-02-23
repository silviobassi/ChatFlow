using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Repositories;
using MongoDB.Driver;

namespace ChatBot.Modules.Flow.Features.CreateFlow;

public class ChatFlowRepository(IMongoDatabase database) : IChatFlowRepository
{
    private readonly IMongoCollection<FlowEngineRoot> _collection = database.GetCollection<FlowEngineRoot>("Flows");

    // Salva o fluxo inteiro (com todos os nós dentro)
    public async Task SaveAsync(FlowEngineRoot flowEngine)
    {
        var flowExists = await _collection.Find(x => x.Id == flowEngine.Id).AnyAsync();

        if (flowExists) throw new InvalidOperationException($"❌ Fluxo '{flowEngine.Id}' já existe.");

        await _collection.InsertOneAsync(flowEngine);
    }

    public async Task UpdateAsync(FlowEngineRoot flowEngine)
    {
        var filter = Builders<FlowEngineRoot>.Filter.Eq(x => x.Id, flowEngine.Id);
        var result = await _collection.ReplaceOneAsync(filter, flowEngine);

        if (result.MatchedCount == 0)
            throw new InvalidOperationException($"❌ Fluxo '{flowEngine.Id}' não encontrado para atualização.");
    }

    public async Task<FlowEngineRoot?> GetFlowByIdAsync(string flowId)
    {
        return await _collection.Find(x => x.Id == flowId).FirstOrDefaultAsync();
    }

    public async Task<FlowEngineRoot?> GetByTriggerAsync(string keyword)
    {
        var filter = Builders<FlowEngineRoot>.Filter.And(
            Builders<FlowEngineRoot>.Filter.Eq(x => x.IsActive, true),
            Builders<FlowEngineRoot>.Filter.Eq(x => x.TriggerKeyword, keyword)
        );

        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
}