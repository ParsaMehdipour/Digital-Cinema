using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;
public sealed class Address : ValueObject
{
    private const int MaxLength = 1000;

    private Address(string value) => Value = value;

    public string Value { get; }

    public Result<Address> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<Address>(DomainErrors.Address.Empty);

        if (value.Length > MaxLength)
            return Result.Failure<Address>(DomainErrors.Address.TooLong);

        return new Address(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
