using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Repositories;
using ChatBot.Infrastructure.Flow.Persistence.MongoDb;
using ChatBot.Modules.Flow.Features.AddContactNode;
using ChatBot.Modules.Flow.Features.CreateFlow;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace ChatBot.Modules.Flow;

public static class ChatNodeFeatures
{
    extension(WebApplicationBuilder builder)
    {
        public WebApplicationBuilder MapChatFlowPersistence()
        {
            MongoDbPersistenceConfig.Configure();

            var mongoSettings = builder.Configuration
                .GetSection(MongoDbSettings.SectionName)
                .Get<MongoDbSettings>();

            // Fail Fast: Se não leu o arquivo, a API nem sobe.
            if (mongoSettings is null || string.IsNullOrWhiteSpace(mongoSettings.DatabaseName))
            {
                throw new InvalidOperationException(
                    "A configuração 'MongoDbSettings:DatabaseName' não foi encontrada no appsettings.json");
            }

            var connectionString = builder.Configuration.GetConnectionString("MongoDb");

            builder.Services.AddScoped<IMongoDatabase>(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();

                // AQUI: Usamos a variável explicitamente. 
                // Se mudarmos o nome no JSON, muda aqui automaticamente.
                return client.GetDatabase(mongoSettings.DatabaseName);
            });

            builder.Services.AddSingleton<IMongoClient>(_ => new MongoClient(connectionString));

            return builder;
        }

        public WebApplicationBuilder MapChatFlowRepository()
        {
            builder.Services
                .AddScoped<IChatFlowRepository, ChatFlowRepository>()
                .AddScoped<IChatNodeRepository, ChatNodeRepository>();

            return builder;
        }
    }

    extension(IEndpointRouteBuilder app)
    {
        public IEndpointRouteBuilder MapChatFlowEndpoints()
        {
            return app.MapButtonListEndpoint()
                .MapContactEndpoint()
                .MapResponseButtonEndpoint()
                .MapTextEndpoint()
                .MapDocumentEndpoint()
                .MapNodeUpdateEndpoint()
                .MapAddContactNodeEndpoints();
        }
    }
}