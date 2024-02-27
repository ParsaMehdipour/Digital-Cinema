using Domain.Entities.Movies.Events;
using Domain.Enums;
using Domain.Repositories.DomainEvent;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.UserServices.Interfaces;

namespace Domain.DomainEvents.Handlers;

/// <summary>
/// Handle's the event in which a movie is being deleted
/// </summary>
/// <param name="domainEventRepository"></param>
/// <param name="logger"></param>
/// <param name="currentUserService"></param>
internal class MovieDeletedDomainEventHandler(IDomainEventRepository domainEventRepository, ILogger<MovieDeletedDomainEventHandler> logger, ICurrentUserService currentUserService) : INotificationHandler<MovieUpdatedDomainEvent>
{
    public async Task Handle(MovieUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling domain event {state} ...", DomainEventState.Deleted.ToString());


        DomainEvent domainEvent = new()
        {
            TableName = nameof(notification.Movie),
            Data = "",
            TableRecordId = notification.Movie.Id.ToString(),
            State = DomainEventState.Deleted,
            UserId = currentUserService.UserId
        };

        await domainEventRepository.InsertOneAsync(domainEvent);

        logger.LogInformation("Domain event handled {id}", domainEvent.Id);
    }
}
