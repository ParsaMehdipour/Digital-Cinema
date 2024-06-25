using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;
public sealed class TrailerDurationInMinutes : ValueObject
{
    public const int MaxDuration = 5;

    private TrailerDurationInMinutes()
    {

    }

    private TrailerDurationInMinutes(int value) => Value = value;

    public int Value { get; }

    public static Result<TrailerDurationInMinutes> Create(int value)
    {
        if (value < 0)
            return Result.Failure<TrailerDurationInMinutes>(DomainErrors.TrailerDurationInMinutes.Negative);

        if (value == 0)
            return Result.Failure<TrailerDurationInMinutes>(DomainErrors.TrailerDurationInMinutes.Zero);

        if (value > MaxDuration)
            return Result.Failure<TrailerDurationInMinutes>(DomainErrors.TrailerDurationInMinutes.TooLong);

        return new TrailerDurationInMinutes(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
