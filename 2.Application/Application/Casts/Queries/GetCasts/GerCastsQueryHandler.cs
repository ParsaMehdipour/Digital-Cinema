using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Repositories;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Pagination;

namespace Application.Casts.Queries.GetCasts;

/// <summary>
/// Represents a get casts query handler
/// </summary>
public class GerCastsQueryHandler : IRequestHandler<GetCastsQuery, Result<PagedResult<GetCastsDto>>>
{
    private readonly ICastRepository _repository;
    private readonly IMapper _mapper;

    public GerCastsQueryHandler(ICastRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary> 
    /// Handles the get casts query
    /// </summary>
    /// <param name="request">Request</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the paged result of get casts dto
    /// </returns>
    public async Task<Result<PagedResult<GetCastsDto>>> Handle(GetCastsQuery request, CancellationToken cancellationToken)
    {
        //Set query
        var casts = _repository.Get();

        //Todo : Study sieve -> To reduce if statement counts

        //Set the filters
        if (request.Parameters.IsDeleted)
            casts = casts.IgnoreQueryFilters().Where(c => c.IsDeleted == true);

        if (string.IsNullOrWhiteSpace(request.Parameters.FirstName) is false)
            casts = casts.Where(c => c.FirstName.Value.Contains(request.Parameters.FirstName));

        if (string.IsNullOrWhiteSpace(request.Parameters.LastName) is false)
            casts = casts.Where(c => c.LastName.Value.Contains(request.Parameters.LastName));

        if (request.Parameters.Age is not null)
            casts = casts.Where(c => c.Age.Value == request.Parameters.Age);

        //Create the result
        var projectedQuery = casts
         .OrderByDescending(c => c.CreatedOnUtc)
         .ProjectTo<GetCastsDto>(_mapper.ConfigurationProvider);

        //Create the paged result
        var pagedResult = projectedQuery.ToPageResult(request.Parameters.PageNumber, request.Parameters.PageSize);

        return Result.Ok(pagedResult);
    }
}
