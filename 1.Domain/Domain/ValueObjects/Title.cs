using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;
public sealed class Title : ValueObject
{
    private const int MaxLength = 100;

    private Title(string value) => Value = value;

    public string Value { get; }

    public Result<Title> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<Title>(DomainErrors.Title.Empty);

        if (value.Length > MaxLength)
            return Result.Failure<Title>(DomainErrors.Title.TooLong);

        return new Title(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
