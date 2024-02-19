using Domain.DomainEvents.Commands;
using MediatR;

namespace Domain.DomainEvents.Handlers;
internal class DomainEventHandler : INotificationHandler<CreateDomainEventCommand>
{
    public Task Handle(CreateDomainEventCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
