using Domain.Enums;
using Domain.Primitives;

namespace Domain.Entities;

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

    public void SetCastId(Guid castId) => CastId = castId;

    public void SetMovieId(Guid movieId) => MovieId = movieId;

    public void SetCastType(CastType castType) => CastType = castType;

    #endregion
}
