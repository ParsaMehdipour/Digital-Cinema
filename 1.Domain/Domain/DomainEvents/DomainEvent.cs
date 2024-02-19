using Domain.Enums;
using Domain.Primitives;

namespace Domain.DomainEvents;

public class DomainEvent : Entity
{
    #region Fields

    public string TableName { get; set; } = string.Empty;
    public string TableRecordId { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
    public DomainEventState State { get; set; }
    public Guid UserId { get; set; } = Guid.Empty;

    #endregion

    #region Ctor

    public DomainEvent() { }

    #endregion
}

