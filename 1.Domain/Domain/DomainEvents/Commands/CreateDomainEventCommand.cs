using Domain.Enums;
using Domain.Primitives;

namespace Domain.DomainEvents.Commands;

internal class CreateDomainEventCommand : IDomainEvent
{
    public string TableName { get; set; } = string.Empty;
    public string TableRecordId { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
    public DomainEventState State { get; set; }
}
