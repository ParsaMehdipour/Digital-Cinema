using Domain.Exceptions;

namespace Application.Casts.Commands.Exceptions;

/// <summary>
/// Represents a cast not found exception
/// </summary>
public class CastNotFoundException : DomainException
{
    private const string _message = "Fetch failed: Cast with the Id of {0} is not found";

    public CastNotFoundException(string castId) : base(string.Format(_message, castId))
    {

    }
}
