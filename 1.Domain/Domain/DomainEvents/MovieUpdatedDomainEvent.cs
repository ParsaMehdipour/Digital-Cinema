using Domain.Entities;

namespace Domain.DomainEvents;

public class MovieUpdatedDomainEvent : DomainEvent
{

    #region Fields

    public Movie Movie { get; init; }

    #endregion

    #region Ctor

    public MovieUpdatedDomainEvent(Movie movie) => Movie = movie;

    #endregion

}
