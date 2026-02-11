namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.TextOption;

public record TextOptionDto(string To, TextContent Text) : MessageBaseDto(To, "text", RecipientType: "individual");