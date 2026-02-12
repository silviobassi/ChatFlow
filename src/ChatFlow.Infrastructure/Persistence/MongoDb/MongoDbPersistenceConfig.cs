using ChatFlow.Domain.Aggregates.FlowAggregate.Buttons;
using ChatFlow.Domain.Aggregates.FlowAggregate.Footers;
using ChatFlow.Domain.Aggregates.FlowAggregate.Headers;
using ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;
using ChatFlow.Domain.Aggregates.FlowAggregate.Options;
using ChatFlow.Domain.Aggregates.FlowAggregate.ValuesObject;
using MongoDB.Bson.Serialization;

namespace ChatFlow.Infrastructure.Persistence.MongoDb;

public static class MongoDbPersistenceConfig
{
    public static void Configure()
    {
        // ===================================================================================
        // 1. CHAT FLOW (NOVA RAIZ DO AGREGADO)
        // ===================================================================================
        BsonClassMap.RegisterClassMap<Domain.Aggregates.FlowAggregate.ChatFlowRoot>(cm =>
        {
            cm.AutoMap();
            cm.SetIsRootClass(true); // Define que este é o documento principal no Mongo

            // Mapeia a propriedade 'Id' do fluxo para o '_id' do MongoDB
            cm.MapIdMember(c => c.Id);

            // IMPORTANTE: Mapeia a lista privada '_nodes' para ser salva como "Nodes" no JSON
            cm.MapField("_nodes").SetElementName("Nodes");
        });

        // ===================================================================================
        // 2. CHAT NODE (POLIMORFISMO DE NÓS)
        // ===================================================================================
        BsonClassMap.RegisterClassMap<ChatNode>(cm =>
        {
            cm.AutoMap();
            
            // NodeId agora é um campo normal, essencial para buscas dentro do array
            cm.MapMember(c => c.NodeId);

            // Mapeia a lista privada '_options' de cada nó
            cm.MapField("_options").SetElementName("Options");

            // Registra a hierarquia (Discriminator _t)
            cm.AddKnownType(typeof(ContactNode));
            cm.AddKnownType(typeof(DocumentNode));
            cm.AddKnownType(typeof(ListButtonNode));
            cm.AddKnownType(typeof(ResponseButtonNode));
            cm.AddKnownType(typeof(TextNode));
        });

        // Registro das Implementações Concretas de Nós
        BsonClassMap.RegisterClassMap<ContactNode>();
        BsonClassMap.RegisterClassMap<DocumentNode>();
        BsonClassMap.RegisterClassMap<ListButtonNode>();
        BsonClassMap.RegisterClassMap<ResponseButtonNode>();
        BsonClassMap.RegisterClassMap<TextNode>();

        // ===================================================================================
        // 3. HEADERS (POLIMORFISMO DE CABEÇALHO)
        // ===================================================================================
        BsonClassMap.RegisterClassMap<Header>(cm =>
        {
            cm.AutoMap();
            cm.SetIsRootClass(true); // Raiz da hierarquia de Headers (ok manter true aqui)

            // Registra os tipos de Header conhecidos
            cm.AddKnownType(typeof(HeaderText));
            cm.AddKnownType(typeof(HeaderImageUrl));
            cm.AddKnownType(typeof(HeaderImageId));
        });

        BsonClassMap.RegisterClassMap<HeaderText>();
        BsonClassMap.RegisterClassMap<HeaderImageUrl>();
        BsonClassMap.RegisterClassMap<HeaderImageId>();

        // ===================================================================================
        // 4. VALUE OBJECTS E STRUCTS
        // ===================================================================================
        // Agrupamento de Botões e Listas
        BsonClassMap.RegisterClassMap<FooterText>();
        BsonClassMap.RegisterClassMap<ButtonText>();
        BsonClassMap.RegisterClassMap<SectionButton>();
        BsonClassMap.RegisterClassMap<RowListButton>();
        BsonClassMap.RegisterClassMap<ChatOption>();

        // Mapeamento explícito para ButtonReply para garantir que o 'Type' seja salvo
        BsonClassMap.RegisterClassMap<ButtonReply>(cm =>
        {
            cm.AutoMap();
            // Se você não usou 'init' na struct, descomente a linha abaixo para forçar a persistência:
            // cm.MapMember(x => x.Type); 
        });

        // Value Objects de Contato e Documento (Importante para ContactNode e DocumentNode)
        BsonClassMap.RegisterClassMap<ContactName>();
        BsonClassMap.RegisterClassMap<ContactPhone>();
        BsonClassMap.RegisterClassMap<DocumentContent>();
        BsonClassMap.RegisterClassMap<TextContent>();
    }
}