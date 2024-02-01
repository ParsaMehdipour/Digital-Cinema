namespace Domain.DomainEvents;

public sealed record MovieCreatedDomainEvent(Guid Id, Guid MovieId) : DomainEvent(Id);