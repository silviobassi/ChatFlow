using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Buttons;
using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Footers;
using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Headers;
using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;
using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.ValuesObject;
using Integrator.ChatFlow.Modules.Features.FlowCreate;
using Integrator.ChatFlow.Modules.Features.FlowCreate.Options.DocumentOption;
using Integrator.ChatFlow.Modules.Features.FlowCreate.Options.TextOption;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TextContent = Integrator.ChatFlow.Modules.Features.FlowCreate.Options.TextOption.TextContent;

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
                    Header: new HeaderImageUrl("https://example.com/header-image.jpg"),
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
                var document = new DocumentOptionDto("5511999999999", new DocumentContentDto(
                    Id: "doc_id",
                    Caption: "Documento de exemplo",
                    FileName: "document.pdf"
                ));

                return Results.Ok(document);
            });

            return endpoint;
        }

        public IEndpointRouteBuilder MapTextEndpoint()
        {
            endpoint.MapGet("/text-option", () =>
            {
                var text = new TextOptionDto("5511999999999", new TextContent(
                    Body: "Olá! Este é um texto de exemplo."
                ));
                return Results.Ok(text);
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