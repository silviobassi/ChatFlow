namespace ChatFlow.Infrastructure.Persistence.MongoDb;

public record MongoDbSettings
{
    public const string SectionName = "MongoDbSettings";
    public string DatabaseName { get; init; } = null!;
}