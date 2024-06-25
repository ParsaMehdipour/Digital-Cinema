using Application.Casts.Queries.GetCasts.Criteria;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore.Pagination;

namespace Application.Casts.Queries.GetCasts;

public record GetCastsQuery(CastsQueryStringParameters Parameters) : IRequest<Result<PagedResult<GetCastCastsDto>>>;

public record GetCastCastsDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int? Age { get; set; }
    public bool IsAlive { get; set; }
}