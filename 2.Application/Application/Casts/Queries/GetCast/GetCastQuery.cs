using Application.Movies.DataTransferObjects;
using FluentResults;
using MediatR;

namespace Application.Casts.Queries.GetCast;

public record GetCastQuery(Guid Id) : IRequest<Result<CastDto>>;

