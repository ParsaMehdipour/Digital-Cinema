using MediatR;

namespace Domain.Primitives;
public interface IDomainEvent : INotification
{
    public Guid Id { get; init; }
}
