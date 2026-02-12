namespace ChatFlow.Modules.Nodes.Features.FlowCreate.Options.TextOption;

public record TextOptionDto(string To, TextContentDto Text) : MessageBaseDto("whatsapp", "individual", To, "text");