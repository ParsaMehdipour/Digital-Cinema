using Domain.Entities.Movies.Events;
using Domain.Enums;
using Domain.Repositories.DomainEvent;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.UserServices.Interfaces;
using System.Text.Json;

namespace Domain.DomainEvents.Handlers;
internal class MovieUpdatedDomainEventHandler(IDomainEventRepository domainEventRepository, ILogger<MovieUpdatedDomainEventHandler> logger, ICurrentUserService currentUserService)
: INotificationHandler<MovieUpdatedDomainEvent>
{
    public async Task Handle(MovieUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling domain event {state} ...", DomainEventState.Updated.ToString());


        DomainEvent domainEvent = new()
        {
            TableName = nameof(notification.Movie),
            Data = JsonSerializer.Serialize(notification.Movie),
            State = DomainEventState.Updated,
            UserId = currentUserService.UserId
        };

        await domainEventRepository.InsertOneAsync(domainEvent);

        logger.LogInformation("Domain event handled {id}", domainEvent.Id);
    }
}
