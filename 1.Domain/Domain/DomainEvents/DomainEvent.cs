using Domain.Primitives;

namespace Domain.DomainEvents;

public abstract record DomainEvent(Guid Id) : IDomainEvent;

