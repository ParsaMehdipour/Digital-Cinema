using Domain.Primitives;

namespace Domain.DomainEvents;

public class DomainEvent : IDomainEvent
{
    #region Fields

    public Guid Id { get; set; }
    public string TableName { get; set; } = string.Empty;
    public string TableRecordId { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
    public Guid UserId { get; set; } = Guid.Empty;

    #endregion

    #region Ctor

    public DomainEvent() { }

    #endregion
}

