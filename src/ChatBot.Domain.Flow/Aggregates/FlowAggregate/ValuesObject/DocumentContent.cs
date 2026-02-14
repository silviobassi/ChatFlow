namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

// create business rules for input DocumentLink or DocumentId, just one of them must be provided
public sealed record DocumentContent(
    string Filename,
    DocumentMedia Media,
    string? Caption = null
);

public abstract record DocumentMedia(string Value);

// Validate that the DocumentLink is a valid URL (e.g., https://example.com/document.pdf | .txt | .xls | .xlsx | .doc | .docx | .ppt | .pptx | .pdf)
public sealed record DocumentLink(string Value) : DocumentMedia(Value)
{
    public static implicit operator string(DocumentLink documentLink) => documentLink.Value;
}

// Validate that the DocumentId is a valid ID (e.g., 1376223850470843)
public sealed record DocumentId(string Value) : DocumentMedia(Value)
{
    public static implicit operator string(DocumentId documentId) => documentId.Value;
}