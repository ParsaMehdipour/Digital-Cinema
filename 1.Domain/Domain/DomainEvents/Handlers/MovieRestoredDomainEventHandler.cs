using Domain.Entities.Movies.Events;
using Domain.Enums;
using Domain.Repositories.DomainEvent;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.UserServices.Interfaces;

namespace Domain.DomainEvents.Handlers;
internal class MovieRestoredDomainEventHandler(IDomainEventRepository domainEventRepository, ILogger<MovieRestoredDomainEventHandler> logger, ICurrentUserService currentUserService)
    : INotificationHandler<MovieRestoredDomainEvent>
{
    public async Task Handle(MovieRestoredDomainEvent notification, CancellationToken cancellationToken)
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
