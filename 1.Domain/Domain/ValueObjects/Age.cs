using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class Age : ValueObject
{
    private const int MinNumber = 0;
    private const int MaxNumber = 120;

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

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
