namespace ChatBot.Domain.Flow.Aggregates.ChatSessionAggregate.ValuesObject;

public sealed record ConversationActor
{
    public string TenantPhoneNumber { get; } 
    public string CustomerPhoneNumber { get; } 
    public string? HumanAttendantName { get; }

    private ConversationActor(string tenantPhoneNumber, string customerPhoneNumber, string? humanAttendantName = null)
    {
        TenantPhoneNumber = tenantPhoneNumber;
        CustomerPhoneNumber = customerPhoneNumber;
        HumanAttendantName = humanAttendantName;
    }

    public ConversationActor InsertHumanAttendant(string humanAttendantName)
        => new(TenantPhoneNumber, CustomerPhoneNumber, humanAttendantName);
}