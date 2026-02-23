using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Nodes;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.ValuesObject;

namespace ChatBot.Modules.Flow.Features.AddContactNode;

public static class ContactCommandMapper
{
    extension(AddContactNodeCommand command)
    {
        public ContactNode ToContactNode() => new(
            command.NodeId,
            command.Name,
            command.MessageText,
            new ContactName(command.FormattedName, command.FirstName, command.LastName),
            command.Phones.Select(p => new ContactPhone(p.WaId, p.PhoneHumber, p.Type)).ToList()
        );
    }
}