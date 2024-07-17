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
public class GetCastQueryHandler : IRequestHandler<GetCastQuery, Result<GetCastDto>>
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
    /// A task that represents the asynchronous operation
    /// The task result contains the cast dto with the same identifier
    /// </returns>
    /// <exception cref="CastNotFoundException">Thrown when no cast is found with the given identifier</exception>
    public async Task<Result<GetCastDto>> Handle(GetCastQuery request, CancellationToken cancellationToken)
    {
        //Log the operation
        _logger.LogInformation($"Initializing fetch : cast with the id of {request.Id}");

        //Fetch the cast
        Cast cast = await _repository.GetByIdAsync(cancellationToken, request.Id);

        //Throw an exception if the cast is not found
        if (cast is null)
            throw new CastNotFoundException(request.Id.ToString());

        //Map the cast model
        GetCastDto castDto = _mapper.Map<GetCastDto>(cast);

        return Result.Ok(castDto);
    }
}
