using Domain.DomainEvents.Commands;
using Domain.Repositories.DomainEvent;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.UserServices.Interfaces;

namespace Domain.DomainEvents.Handlers;
internal class DomainEventHandler(IDomainEventRepository domainEventRepository, ILogger<DomainEventHandler> logger, ICurrentUserService currentUserService)
    : INotificationHandler<CreateDomainEventCommand>
{
    public async Task Handle(CreateDomainEventCommand notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling domain event {state} ...", notification.State.ToString());

        DomainEvent domainEvent = new()
        {
            TableName = notification.TableName,
            TableRecordId = notification.TableRecordId,
            Data = notification.Data,
            State = notification.State,
            UserId = currentUserService.UserId
        };

        await domainEventRepository.InsertOneAsync(domainEvent);

        logger.LogInformation("Domain event handled {id}", domainEvent.Id);

    }
}
