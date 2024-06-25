using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class MovieDurationInMinutes : ValueObject
{
    public const int MaxDuration = 5100;

    private MovieDurationInMinutes()
    {

    }

    private MovieDurationInMinutes(int value) => Value = value;

    public int Value { get; }

    public static Result<MovieDurationInMinutes> Create(int value)
    {
        if (value < 0)
            return Result.Failure<MovieDurationInMinutes>(DomainErrors.MovieDurationInMinutes.Negative);

        if (value == 0)
            return Result.Failure<MovieDurationInMinutes>(DomainErrors.MovieDurationInMinutes.Zero);

        if (value > MaxDuration)
            return Result.Failure<MovieDurationInMinutes>(DomainErrors.MovieDurationInMinutes.TooLong);

        return new MovieDurationInMinutes(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
