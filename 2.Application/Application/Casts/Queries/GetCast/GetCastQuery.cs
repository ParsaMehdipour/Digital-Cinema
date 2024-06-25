using FluentResults;
using MediatR;

namespace Application.Casts.Queries.GetCast;

/// <summary>
/// Represents a get cast query
/// </summary>
/// <param name="Id"></param>
public record GetCastQuery(Guid Id) : IRequest<Result<GetCastCastDto>>;

/// <summary>
/// Represents a get cast dto
/// </summary>
public record GetCastCastDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int? Age { get; set; }
    public bool IsAlive { get; set; }
}