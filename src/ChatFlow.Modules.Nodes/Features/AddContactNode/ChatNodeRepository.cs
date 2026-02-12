using ChatFlow.Domain.Aggregates.FlowAggregate;
using ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;
using ChatFlow.Domain.Aggregates.FlowAggregate.Repositories;
using MongoDB.Driver;

namespace ChatFlow.Modules.Nodes.Features.AddContactNode;

public class ChatNodeRepository(IMongoDatabase database) : IChatNodeRepository
{
    private readonly IMongoCollection<ChatFlowRoot> _collection = database.GetCollection<ChatFlowRoot>("Flows");

    public async Task AddNodeAsync(string flowId, ChatNode newNode)
    {
        // 1. O Filtro garante duas coisas:
        //    a) Encontra o fluxo pelo ID correto.
        //    b) Garante que NENHUM nó existente tenha o mesmo NodeId (Prevenção de Duplicidade Atômica)
        var filter = Builders<ChatFlowRoot>.Filter.And(
            Builders<ChatFlowRoot>.Filter.Eq(x => x.Id, flowId),
            Builders<ChatFlowRoot>.Filter.Ne("Nodes.NodeId", newNode.NodeId) // "Ne" = Not Equal
        );

        // 2. O Update usa $push para adicionar ao array "Nodes"
        var update = Builders<ChatFlowRoot>.Update.Push("Nodes", newNode);

        var result = await _collection.UpdateOneAsync(filter, update);

        // 3. Validação do Resultado
        if (result.MatchedCount == 0)
        {
            // Se MatchedCount for 0, pode ser porque:
            // A) O fluxo não existe.
            // B) O fluxo existe, mas já tem um nó com esse ID (caiu no filtro Ne).

            // Vamos verificar qual foi o caso para dar o erro correto:
            var flowExists = await _collection
                .Find(x => x.Id == flowId)
                .AnyAsync();

            if (!flowExists)
                throw new InvalidOperationException($"Fluxo '{flowId}' não encontrado.");
            
            throw new InvalidOperationException($"O nó '{newNode.NodeId}' já existe neste fluxo.");
        }
    }
}