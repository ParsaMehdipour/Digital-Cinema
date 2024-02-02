using Domain.Primitives;

namespace Domain.Entities;
public class MoviePlay : Entity
{
    #region Fields

    public Guid HallId { get; private set; }

    public Guid MovieId { get; private set; }

    #endregion

    #region Ctor

    private MoviePlay() { }

    private MoviePlay(Guid hallId, Guid movieId)
    {
        SetHallId(hallId);
        SetMovieId(movieId);
    }

    #endregion

    #region Methods

    public MoviePlay Create(Guid hallId, Guid movieId) => new(hallId, movieId);

    public void SetHallId(Guid hallId)
    {
        if (hallId == Guid.Empty) return;

        if (HallId.Equals(hallId)) return;

        HallId = hallId;
    }

    public void SetMovieId(Guid movieId)
    {
        if (movieId == Guid.Empty) return;

        if (MovieId.Equals(movieId)) return;

        MovieId = movieId;
    }

    #endregion
}
