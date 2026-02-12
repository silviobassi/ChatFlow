namespace ChatFlow.Modules.Nodes.Features.AddContactNode;

public sealed record AddContactNodeCommand(
    string FlowId,
    string NodeId,
    string Name,
    string MessageText,
    string FormattedName,
    string? FirstName,
    string? LastName,
    List<Phone> Phones
);

public sealed record Phone(string WaId, string? PhoneHumber = null, string? Type = null);