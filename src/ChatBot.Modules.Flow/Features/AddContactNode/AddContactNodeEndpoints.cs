using System.Text.Json.Serialization;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ChatBot.Modules.Flow.Features.AddContactNode;

public static class AddContactNodeEndpoints
{
    extension(IEndpointRouteBuilder app)
    {
        public IEndpointRouteBuilder MapAddContactNodeEndpoints()
        {
            app.MapPost("/add-contact-node", async (AddContactNodeCommand command, IChatNodeRepository repository) =>
            {
                var node = command.ToContactNode();
                await repository.AddNodeAsync(command.FlowId, node);
                return Results.Ok(new { NodeId = node.NodeId });
            });

            return app;
        }
    }
}