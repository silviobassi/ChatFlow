namespace ChatFlow.Modules.Nodes.Features.MapFlow.Options.TextOption;

public record TextOptionDto(string To, TextContentDto Text) : MessageBaseDto("whatsapp", "individual", To, "text");