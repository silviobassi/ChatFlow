namespace ChatBot.Domain.Flow.Aggregates.SessionAggregate;

public class UserSession(string userPhoneNumber, string startNodeId)
{
    // Identificador único da sessão no banco
    public Guid Id { get; private set; } = Guid.NewGuid();

    // O "Dono" da sessão (Chave de Negócio)
    public string UserPhoneNumber { get; private set; } = userPhoneNumber;

    // Onde o usuário está agora? (Ex: "menu_principal", "aguardando_cpf")
    public string CurrentNodeId { get; private set; } = startNodeId;

    // A "Memória" do Bot. Guarda, dados capturados (CPF, Protocolo, Nome)
    // Usamos um Dicionário para flexibilidade (chave/valor)
    private readonly Dictionary<string, string> _contextData = new();
    public IReadOnlyDictionary<string, string> ContextData => _contextData;

    // Controle de tempo para expiração de sessão
    public DateTime LastInteractionAt { get; private set; } = DateTime.UtcNow;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public bool IsActive { get; private set; } = true;

    // Construtor para criar uma NOVA sessão

    // --- Comportamentos (Métodos de Domínio) ---

    // 1. Transição de Estado: Move o usuário e atualiza o tempo
    public void TransitionTo(string nextNodeId)
    {
        if (!IsActive) throw new InvalidOperationException("Sessão inativa.");
        
        CurrentNodeId = nextNodeId;
        LastInteractionAt = DateTime.UtcNow;
    }

    // 2. Enriquecimento de Contexto: Guarda uma informação fornecida pelo usuário
    public void AddContextData(string key, string value)
    {
        if (!_contextData.TryAdd(key, value))
            _contextData[key] = value; // Atualiza se já existe

        LastInteractionAt = DateTime.UtcNow;
    }

    // 3. Recuperação de Contexto: Facilita ler dados (ex: pegar o CPF guardado)
    public string? GetContextData(string key)
    {
        return _contextData.GetValueOrDefault(key);
    }

    // 4. Regra de Negócio: Verifica expiração (Timeout)
    public bool CheckExpiration(int timeoutInMinutes)
    {
        var timeSinceLastInteraction = DateTime.UtcNow - LastInteractionAt;
        if (!(timeSinceLastInteraction.TotalMinutes > timeoutInMinutes)) return false; // Ainda válida
        IsActive = false;
        return true; // Expirou
    }
}