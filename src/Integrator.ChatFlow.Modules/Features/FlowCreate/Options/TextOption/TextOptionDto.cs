namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.TextOption;

public record TextOptionDto(string To, TextContentDto Text) : MessageBaseDto("whatsapp", "individual", To, "text");