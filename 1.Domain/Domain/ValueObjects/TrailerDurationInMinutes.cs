using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;
public sealed class TrailerDurationInMinutes : ValueObject
{
    private const int MaxDuration = 5;

    private TrailerDurationInMinutes(int value) => Value = value;

    public int Value { get; }

    public Result<TrailerDurationInMinutes> Create(int value)
    {
        if (value < 0)
            return Result.Failure<TrailerDurationInMinutes>(DomainErrors.TrailerDurationInMinutes.Negative);

        if (value == 0)
            return Result.Failure<TrailerDurationInMinutes>(DomainErrors.TrailerDurationInMinutes.Zero);

        if (value > MaxDuration)
            return Result.Failure<TrailerDurationInMinutes>(DomainErrors.TrailerDurationInMinutes.TooLong);

        return new TrailerDurationInMinutes(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
