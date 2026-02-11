using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Integrator.ChatFlow.Modules;

public static class ChatNodeFeatures
{
    extension(WebApplicationBuilder builder)
    {
        public WebApplicationBuilder MapChatFlowServices()
        {
            // Register services related to ChatNode here
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
                .MapDocumentEndpoint();
        }
    }
}