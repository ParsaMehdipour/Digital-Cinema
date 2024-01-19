using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class MovieDurationInMinutes : ValueObject
{
    private const int MaxDuration = 5100;

    private MovieDurationInMinutes(int value) => Value = value;

    public int Value { get; }

    public Result<MovieDurationInMinutes> Create(int value)
    {
        if (value < 0)
            return Result.Failure<MovieDurationInMinutes>(DomainErrors.MovieDurationInMinutes.Negative);

        if (value > MaxDuration)
            return Result.Failure<MovieDurationInMinutes>(DomainErrors.MovieDurationInMinutes.TooLong);

        return new MovieDurationInMinutes(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
