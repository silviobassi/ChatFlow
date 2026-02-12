using ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;
using ChatFlow.Domain.Aggregates.FlowAggregate.ValuesObject;
using ChatFlow.Modules.Nodes.Features.MapFlow.Options.ContactOption;

namespace ChatFlow.Modules.Nodes.Features.MapFlow.Mappers;

public static class ContactMapper
{
    extension(ContactNode node)
    {
        public ContactOptionDto ToDo(string userPhone) => new(To: userPhone, Contacts: [node.ToContactDto()]);

        private ContactDto ToContactDto() => new(Name: node.ToContactNameDto(), Phones: node.ToContactPhonesDto());

        private ContactNameDto ToContactNameDto() => new(
            FormattedName: node.ContactName.FormattedName,
            FirstName: node.ContactName.FirstName,
            LastName: node.ContactName.LastName
        );

        private List<ContactPhoneDto> ToContactPhonesDto() =>
            node.Phones.Select(p => p.ToContactPhoneDto()).ToList();
    }

    extension(ContactPhone phone)
    {
        private ContactPhoneDto ToContactPhoneDto() => new(WaId: phone.WaId, Phone: phone.Phone, Type: phone.Type);
    }
}