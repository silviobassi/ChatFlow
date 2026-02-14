using ChatBot.Domain.Flow.Aggregates.FlowAggregate;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Buttons;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Footers;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Headers;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Nodes;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Repositories;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;
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
                var listButtonNode = new ListButtonNode(
                    NodeId: "opcoes_menu_1",
                    Name: "Opções de Menu",
                    MessageText: "Escolha uma opção:",
                    ButtonText: new ButtonText("Ver opções"),
                    HeaderText: new HeaderText("Opções disponíveis"),
                    FooterText: new FooterText("Selecione uma opção para continuar"),
                    SectionsButtons:
                    [
                        new SectionButton(
                            Title: "Seção 1",
                            Rows:
                            [
                                RowListButtonBuilder.Builder("option1", "Opção 1")
                                    .WithDescription("Descrição da Opção 1")
                                    .WithNavigationTargetNode(new NavigationTargetNode("node_opcao_1"))
                                    .Build(),
                                RowListButtonBuilder.Builder("option2", "Opção 2")
                                    .WithDescription("Descrição da Opção 2")
                                    .WithNavigationTargetFlow(new NavigationTargetFlow("fluxo_opcao_2"))
                                    .Build()
                            ]
                        ),
                        new SectionButton(
                            Title: "Seção 2",
                            Rows:
                            [
                                RowListButtonBuilder.Builder("option3", "Opção 3")
                                    .WithNavigationTargetNode(new NavigationTargetNode("node_opcao_3"))
                                    .Build(),
                                RowListButtonBuilder.Builder("option4", "Opção 4")
                                    .WithDescription("Descrição da Opção 4")
                                    .WithNavigationTargetFlow(new NavigationTargetFlow("fluxo_opcao_4"))
                                    .Build()
                            ]
                        )
                    ]
                );

                var flow = new ChatFlowRoot(
                    Id: "fluxo_teste_4",
                    Name: "Fluxo de Teste 1",
                    TriggerKeyword: "menu",
                    IsActive: true
                );

                flow.AddNode(listButtonNode);

                await repository.SaveAsync(flow);

                var listButtonOptionDto = listButtonNode.MapNodeToDto("5511999999999");
                return Results.Ok(listButtonOptionDto);
            });
            return endpoint;
        }

        public IEndpointRouteBuilder MapResponseButtonEndpoint()
        {
            endpoint.MapGet("/response-button-option", async (IChatFlowRepository repository) =>
            {
                var responseButtonNode = new ResponseButtonNode(
                    NodeId: "resposta_rapida_1",
                    Name: "Resposta Rápida",
                    MessageText: "Escolha uma resposta rápida:",
                    ButtonReplies:
                    [
                        new ButtonReply("reply1", "Resposta 1"),
                        new ButtonReply("reply2", "Resposta 2")
                    ],
                    Header: new HeaderImageId("2924382942849"),
                    FooterText: new FooterText("Selecione uma resposta para continuar")
                );

                var flow = new ChatFlowRoot(
                    Id: "fluxo_teste_1",
                    Name: "Fluxo de Teste 1",
                    TriggerKeyword: "menu",
                    IsActive: true
                );

                flow.AddNode(responseButtonNode);

                await repository.SaveAsync(flow);

                var responseButtonOptionDto = responseButtonNode.MapNodeToDto("5511999999999");

                return Results.Ok(responseButtonOptionDto);
            });


            return endpoint;
        }

        public IEndpointRouteBuilder MapDocumentEndpoint()
        {
            endpoint.MapGet("/document-option", () =>
            {
                var documentNode = new DocumentNode(
                    NodeId: "opcoes_menu_1",
                    Name: "Documento de Exemplo",
                    MessageText: "Aqui está um documento de exemplo para você.",
                    DocumentContent: new DocumentContent(
                        Filename: "opcoes_menu_1.docx",
                        Media: new DocumentId("292384092384"),
                        Caption: "Este é um documento de exemplo."
                    )
                );

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
                var contactNode = new ContactNode(
                    NodeId: "contact_node_1",
                    Name: "Contato de Exemplo",
                    MessageText: "Aqui estão os detalhes do contato.",
                    ContactName: new ContactName("João Silva", null, null),
                    Phones: [new ContactPhone("16505551234")]
                );

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