using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities.Trailers;
public class Trailer : Entity
{
    #region Fields

    public Guid MovieId { get; private set; }

    public TrailerDurationInMinutes TrailerDurationInMinutes { get; private set; } = null!;

    public DateTime ReleaseDate { get; private set; }

    public string FilePath { get; private set; } = string.Empty;


    #endregion

    #region Methods

    public void SetMovieId(Guid movieId)
    {
        if (MovieId.Equals(movieId)) return;

        if (movieId == Guid.Empty) return;

        MovieId = movieId;
    }

    public void SetTrailerDurationInMinutes(TrailerDurationInMinutes trailerDurationInMinutes)
    {
        if (TrailerDurationInMinutes.Equals(trailerDurationInMinutes)) return;

        TrailerDurationInMinutes = trailerDurationInMinutes;
    }

    public void SetReleaseDate(DateTime releaseDate)
    {
        if (ReleaseDate.Equals(releaseDate)) return;

        ReleaseDate = releaseDate;
    }

    public void SetFilePath(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath)) return;

        if (FilePath.Equals(filePath)) return;

        FilePath = filePath;
    }

    #endregion
}
