using Domain.Enums;
using Domain.Primitives;

namespace Domain.Entities.MovieCasts;

public class MovieCast : Entity
{
    #region Fields

    public Guid CastId { get; private set; }
    public Guid MovieId { get; private set; }
    public CastType CastType { get; private set; }

    #endregion

    #region Ctor

    private MovieCast(Guid id, Guid castId, Guid movieId, CastType castType) : base(id)
    {
        SetCastId(castId);
        SetMovieId(movieId);
        SetCastType(castType);
    }

    private MovieCast()
    {

    }

    #endregion

    #region Methods

    public MovieCast Create(Guid id, Guid castId, Guid movieId, CastType castType) => new(id, castId, movieId, castType);

    public void SetCastId(Guid castId)
    {
        if (CastId.Equals(castId)) return;

        if (castId == Guid.Empty) return;

        CastId = castId;
    }

    public void SetMovieId(Guid movieId)
    {
        if (MovieId.Equals(movieId)) return;

        if (movieId == Guid.Empty) return;

        MovieId = movieId;
    }

    public void SetCastType(CastType castType)
    {
        if (CastType.Equals(castType)) return;

        CastType = castType;
    }

    #endregion
}
