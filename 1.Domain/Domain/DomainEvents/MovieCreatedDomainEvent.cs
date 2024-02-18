using Domain.Entities.Movies;

namespace Domain.DomainEvents;

public sealed class MovieCreatedDomainEvent : DomainEvent
{
    #region Fields

    public Movie Movie { get; init; }


    #endregion

    #region Ctor

    public MovieCreatedDomainEvent(Movie movie) => Movie = movie;

    #endregion
}
