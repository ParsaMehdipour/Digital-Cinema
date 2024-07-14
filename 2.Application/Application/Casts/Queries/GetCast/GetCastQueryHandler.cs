using Application.Casts.Commands.Exceptions;
using AutoMapper;
using Domain.Entities.Casts;
using Domain.Repositories;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Casts.Queries.GetCast;

/// <summary>
/// Represents a get cast query handler
/// </summary>
public class GetCastQueryHandler : IRequestHandler<GetCastQuery, Result<GetCastCastDto>>
{
    private readonly ICastRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetCastQueryHandler> _logger;

    public GetCastQueryHandler(ICastRepository repository, IMapper mapper, ILogger<GetCastQueryHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handles the get cast query
    /// </summary>
    /// <param name="request">Request</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>
    /// Returns an async result
    /// The Result contains a cast dto
    /// </returns>
    public async Task<Result<GetCastCastDto>> Handle(GetCastQuery request, CancellationToken cancellationToken)
    {
        //Log the operation
        _logger.LogInformation($"Initializing fetch : cast with the id of {request.Id}");

        //Fetch the cast
        Cast cast = await _repository.GetByIdAsync(cancellationToken, request.Id);

        //Throw an exception if the cast is not found
        if (cast is null)
            throw new CastNotFoundException(request.Id.ToString());

        //Map the cast model
        GetCastCastDto castDto = _mapper.Map<GetCastCastDto>(cast);

        return Result.Ok(castDto);
    }
}
