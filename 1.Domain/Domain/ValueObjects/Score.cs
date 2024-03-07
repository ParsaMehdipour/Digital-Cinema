using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class Score : ValueObject
{
    private const int MaxNumber = 10;

    private Score(int value) => Value = value;

    public int Value { get; }

    public static Result<Score> Create(int value)
    {
        if (value < 0)
            return Result.Failure<Score>(DomainErrors.Score.Negative);

        if (value > MaxNumber)
            return Result.Failure<Score>(DomainErrors.Score.TooHigh);

        return new Score(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
