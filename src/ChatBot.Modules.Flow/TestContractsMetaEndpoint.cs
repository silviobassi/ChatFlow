using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Builders;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Buttons;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Footers;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Headers;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Nodes;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Repositories;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.ValuesObject;
using ChatBot.Modules.Flow.Features.MapFlow;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ChatBot.Modules.Flow;

public static class TestContractsMetaEndpoint
{
    extension(IEndpointRouteBuilder endpoint)
    {
        public IEndpointRouteBuilder MapButtonListEndpoint()
        {
            endpoint.MapGet("/list-button-option", async (IChatFlowRepository repository) =>
            {
                var sectionButton = new SectionButton("Seção 1");
                sectionButton.AddRow(
                    RowListButton.CreateWithTargetFlow("option1",
                        "Opção 1",
                        new TargetFlow("fluxo_opcao_1"),
                        "Descrição da Opção 1"
                    )
                );

                sectionButton.AddRow(
                    RowListButton.CreateWithTargetNode(
                        "Opção 2",
                        "Opção 2",
                        new TargetNode("node_opcao_2")
                    )
                );

                var listButtonNode = new ListButtonNodeBuilder()
                    .WithNodeId("opcoes_menu_1")
                    .WithName("Opções de Menu")
                    .WithMessageText("Escolha uma opção:")
                    .WithButtonText(new ButtonText("Ver opções"))
                    .WithHeaderText(new HeaderText("Opções disponíveis"))
                    .WithFooterText(new FooterText("Selecione uma opção para continuar"))
                    .AddSectionButton(sectionButton)
                    .Build();

                var flow = new FlowEngineRoot(
                    Id: "fluxo_teste_4",
                    Name: "Fluxo de Teste 1",
                    TriggerKeyword: "menu",
                    IsActive: true,
                    TenantId: 1,
                    ConfigurationId: 1,
                    CampaignId: "12233333"
                );

                /*flow.AddNode(listButtonNode);

                await repository.SaveAsync(flow);*/

                var listButtonOptionDto = listButtonNode.MapNodeToDto("5511999999999");
                return Results.Ok(listButtonOptionDto);
            });
            return endpoint;
        }

        public IEndpointRouteBuilder MapResponseButtonEndpoint()
        {
            endpoint.MapGet("/response-button-option", async (IChatFlowRepository repository) =>
            {
                var responseButtonNode = new ResponseButtonNodeBuilder()
                    .WithNodeId("resposta_rapida_1")
                    .WithName("Resposta Rápida")
                    .WithMessageText("Escolha uma resposta rápida:")
                    .AddButtonReply(ButtonReply.CreateWithTargetNode(
                        "resposta1",
                        "Resposta 1",
                        new TargetNode("node_resposta_1")
                    ))
                    .AddButtonReply(ButtonReply.CreateWithTargetFlow(
                        "resposta2",
                        "Resposta 2",
                        new TargetFlow("fluxo_resposta_2")
                    ))
                    .WithHeader(new HeaderImageId("2924382942849"))
                    .WithFooterText(new FooterText("Selecione uma resposta para continuar"))
                    .Build();

                var flow = new FlowEngineRoot(
                    Id: "fluxo_teste_5",
                    Name: "Fluxo de Teste 1",
                    TriggerKeyword: "menu",
                    IsActive: true,
                    TenantId: 1,
                    ConfigurationId: 1,
                    CampaignId: "12233333"
                );

                /*flow.AddNode(responseButtonNode);

                await repository.SaveAsync(flow);*/

                var responseButtonOptionDto = responseButtonNode.MapNodeToDto("5511999999999");

                return Results.Ok(responseButtonOptionDto);
            });


            return endpoint;
        }

        public IEndpointRouteBuilder MapDocumentEndpoint()
        {
            endpoint.MapGet("/document-option", () =>
            {
                var documentContent = new DocumentContent(
                    Filename: "exemplo.pdf",
                    Media: new DocumentId("106540352242922"),
                    Caption: "Este é um documento de exemplo."
                );

                var documentNode = new DocumentNodeBuilder()
                    .WithNodeId("document_node_1")
                    .WithName("Documento de Exemplo")
                    .WithMessageText("Aqui está um documento de exemplo para você.")
                    .WithDocumentContent(documentContent)
                    .Build();

                var documentOptionDto = documentNode.MapNodeToDto("+16505551234");

                return Results.Ok(documentOptionDto);
            });

            return endpoint;
        }

        public IEndpointRouteBuilder MapTextEndpoint()
        {
            endpoint.MapGet("/text-option", () =>
            {
                var textNode = new TextNode(
                    "text_node_1",
                    "Texto de Exemplo",
                    "Aqui está um texto de exemplo para você.",
                    new TextContent()
                );

                var textOptionDto = textNode.MapNodeToDto("+16505551234");

                return Results.Ok(textOptionDto);
            });

            return endpoint;
        }

        public IEndpointRouteBuilder MapContactEndpoint()
        {
            endpoint.MapGet("/contact-option", () =>
            {
                var contactName = new ContactName("João Silva", null, null);

                var contactNode = new ContactNodeBuilder()
                    .WithNodeId("contact_node_1")
                    .WithName("Contato de Exemplo")
                    .WithMessageText("Aqui estão os detalhes do contato.")
                    .WithContactName(contactName)
                    .AddPhone(new ContactPhone("16505551234"))
                    .AddPhone(new ContactPhone("16505554321", Phone: "1799667575"))
                    .Build();

                var contactOptionDto = contactNode.MapNodeToDto("+16505551234");

                return Results.Ok(contactOptionDto);
            });


            return endpoint;
        }

        public IEndpointRouteBuilder MapNodeUpdateEndpoint()
        {
            endpoint.MapGet("/node/update", async (IChatNodeRepository repository) =>
            {
                var contactNode = new ContactNode(
                    NodeId: "contact_node_1",
                    Name: "Contato de Exemplo",
                    MessageText: "Aqui estão os detalhes do contato.",
                    ContactName: new ContactName("João Silva", null, null),
                    Phones: [new ContactPhone("16505551234")]
                );


                try
                {
                    await repository.AddNodeAsync("fluxo_teste_2", contactNode);
                    Console.WriteLine("✅ Nó adicionado com sucesso!");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"🦀 Erro: {ex.Message}");
                }

                var contactOptionDto = contactNode.MapNodeToDto("+16505551234");

                return Results.Ok(contactOptionDto);
            });


            return endpoint;
        }
    }
}