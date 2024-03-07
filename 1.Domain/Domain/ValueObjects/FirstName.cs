using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class FirstName : ValueObject
{
    public const int MaxLength = 50;

    private FirstName(string value) => Value = value;

    public string Value { get; }

    public static Result<FirstName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<FirstName>(DomainErrors.FirstName.Empty);

        if (value.Length > MaxLength)
            return Result.Failure<FirstName>(DomainErrors.FirstName.TooLong);

        return new FirstName(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

