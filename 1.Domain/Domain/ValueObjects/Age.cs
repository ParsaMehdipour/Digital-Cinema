using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class Age : ValueObject
{
    public const int MinNumber = 0;
    public const int MaxNumber = 120;

    private Age()
    {

    }

    private Age(int value) => Value = value;

    public int Value { get; }

    public static Result<Age> Create(int value)
    {
        if (value is 0)
            return Result.Failure<Age>(DomainErrors.Age.Zero);

        if (value < MinNumber)
            return Result.Failure<Age>(DomainErrors.Age.TooYoung);

        if (value > MaxNumber)
            return Result.Failure<Age>(DomainErrors.Age.TooOld);

        return new Age(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
