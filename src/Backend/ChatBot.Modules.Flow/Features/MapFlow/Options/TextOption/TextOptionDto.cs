namespace ChatBot.Modules.Flow.Features.MapFlow.Options.TextOption;

public record TextOptionDto(string To, TextContentDto Text) : MessageBaseDto("whatsapp", "individual", To, "text");