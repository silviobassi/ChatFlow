using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Buttons;
using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Footers;
using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Headers;
using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;
using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.ValuesObject;
using Integrator.ChatFlow.Modules.Features.FlowCreate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Integrator.ChatFlow.Modules;

public static class TestContractsMetaEndpoint
{
    extension(IEndpointRouteBuilder endpoint)
    {
        public IEndpointRouteBuilder MapButtonListEndpoint()
        {
            endpoint.MapGet("/list-button-option", () =>
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
                                new RowListButton("option1", "Opção 1", "Descrição da Opção 1"),
                                new RowListButton("option2", "Opção 2", "Descrição da Opção 2")
                            ]
                        ),
                        new SectionButton(
                            Title: "Seção 2",
                            Rows:
                            [
                                new RowListButton("option3", "Opção 3", "Descrição da Opção 3"),
                                new RowListButton("option4", "Opção 4", "Descrição da Opção 4")
                            ]
                        )
                    ]
                );

                var listButtonOptionDto = listButtonNode.MapNodeToDto("5511999999999");
                return Results.Ok(listButtonOptionDto);
            });
            return endpoint;
        }

        public IEndpointRouteBuilder MapResponseButtonEndpoint()
        {
            endpoint.MapGet("/response-button-option", () =>
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
    }
}