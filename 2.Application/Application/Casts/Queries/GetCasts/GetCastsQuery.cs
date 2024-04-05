using Application.Movies.DataTransferObjects;
using MediatR;

namespace Application.Casts.Queries.GetCasts;

public class GetCastsQuery : IRequest<IList<CastDto>>
{
}
