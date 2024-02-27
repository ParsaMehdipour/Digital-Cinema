using Domain.Entities.Movies.Events;
using Domain.Enums;
using Domain.Repositories.DomainEvent;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.UserServices.Interfaces;
using System.Text.Json;

namespace Domain.DomainEvents.Handlers;

/// <summary>
/// Handle's the event in which a movie is being created
/// </summary>
/// <param name="domainEventRepository"></param>
/// <param name="logger"></param>
/// <param name="currentUserService"></param>
internal class MovieCreatedDomainEventHandler(IDomainEventRepository domainEventRepository, ILogger<MovieCreatedDomainEventHandler> logger, ICurrentUserService currentUserService)
    : INotificationHandler<MovieCreatedDomainEvent>
{
    public async Task Handle(MovieCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling domain event {state} ...", DomainEventState.Created.ToString());


        DomainEvent domainEvent = new()
        {
            TableName = nameof(notification.Movie),
            Data = JsonSerializer.Serialize(notification.Movie),
            State = DomainEventState.Created,
            UserId = currentUserService.UserId
        };

        await domainEventRepository.InsertOneAsync(domainEvent);

        logger.LogInformation("Domain event handled {id}", domainEvent.Id);
    }
}
