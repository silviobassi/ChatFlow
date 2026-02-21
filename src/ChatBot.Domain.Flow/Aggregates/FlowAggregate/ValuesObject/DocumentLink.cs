namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

public sealed record DocumentLink : DocumentMedia
{
    private static readonly HashSet<string> AllowedExtensions =
    [
        ".pdf", ".txt", ".xls", ".xlsx",
        ".doc", ".docx", ".ppt", ".pptx"
    ];

    public DocumentLink(string Value) : base(Value)
    {
        if (!Uri.TryCreate(Value, UriKind.Absolute, out var uri) || uri.Scheme != Uri.UriSchemeHttps)
        {
            throw new InvalidOperationException(
                $"🦀 O link '{Value}' não é uma URL válida. Informe uma URL válida (ex: https://example.com/document.pdf).");
        }

        var extension = Path.GetExtension(uri.AbsolutePath).ToLowerInvariant();

        if (string.IsNullOrEmpty(extension) || !AllowedExtensions.Contains(extension))
        {
            throw new InvalidOperationException(
                $"🦀 A extensão do documento '{extension}' não é suportada. Extensões válidas: {string.Join(", ", AllowedExtensions)}.");
        }
    }

    public static implicit operator string(DocumentLink documentLink) => documentLink.Value;
}