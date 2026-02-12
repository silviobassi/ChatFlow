using ChatBot.Domain.Flow.Aggregates.SessionAggregate;
using ChatBot.Domain.Flow.Aggregates.SessionAggregate.Repositories;

namespace ChatBot.Modules.Flow.Features.MapFlow;

public class UserMessageProcessorUseCase(IUserSessionRepository repository)
{
    public async Task Execute(string userPhone, string messageText)
    {
        // 1. Recupera a sessão do Mongo
        var session = await repository.GetByPhoneAsync(userPhone);

        // 2. Se não existe ou expirou, cria nova
        if (session.CheckExpiration(30)) // 30 min timeout
        {
            session = new UserSession(userPhone, "start_node");
        }

        // 3. Executa lógica (Ex: se o nó atual esperava um CPF, guarda no contexto)
        if (session.CurrentNodeId == "waiting_cpf")
        {
            session.AddContextData("cpf", messageText);
            session.TransitionTo("check_debt_api");
        }

        // 4. Persiste o novo estado
        await repository.SaveAsync(session);
    }
}