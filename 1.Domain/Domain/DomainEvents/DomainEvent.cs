using Domain.Primitives;

namespace Domain.DomainEvents;

public class DomainEvent : IDomainEvent
{
    #region Fields

    public Guid Id { get; set; }
    public string Data { get; set; } = string.Empty;
    public Guid UserId { get; set; } = Guid.Empty;

    #endregion

    #region Ctor

    public DomainEvent() { }

    #endregion
}

