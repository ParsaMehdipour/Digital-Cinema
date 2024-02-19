using Domain.Primitives;

namespace Domain.DomainEvents.Commands;

internal class CreateDomainEventCommand : IDomainEvent
{
    public string TableName { get; set; } = string.Empty;
    public string TableRecordId { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public Guid UserId { get; set; } = Guid.Empty;

}
