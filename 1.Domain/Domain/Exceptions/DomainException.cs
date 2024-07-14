namespace Domain.Exceptions;

/// <summary>
/// Represents a domain exception
/// </summary>
public abstract class DomainException : Exception
{
    protected DomainException() : base() { }

    protected DomainException(string message)
        : base(message)
    {
    }
}
