﻿using Domain.Entities.Casts;
using Domain.Repositories;
using Domain.Repositories.UnitOfWork;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Casts.Commands.DeleteRestoreCast;

/// <summary>
/// Represents a handler for delete or restore cast command
/// </summary>
public class DeleteRestoreCastCommandHandler : IRequestHandler<DeleteRestoreCastCommand, Result>
{
    private readonly ICastRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DeleteRestoreCastCommandHandler> _logger;

    public DeleteRestoreCastCommandHandler(ICastRepository repository, IUnitOfWork unitOfWork, ILogger<DeleteRestoreCastCommandHandler> logger)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    /// <summary>
    /// Handle method
    /// </summary>
    /// <param name="request">Delete or restore cast command send from the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>
    /// Task returns an asynchronous result
    /// The result specifies whether the cast state change happened or not
    /// </returns>
    public async Task<Result> Handle(DeleteRestoreCastCommand request, CancellationToken cancellationToken)
    {
        //Get the cast by identifier
        Cast cast = await _repository.GetByIdAsync(cancellationToken, request.Id);

        //If the cast is not found
        if (cast is null)
            throw new KeyNotFoundException($"Fetch failed: Cast with the Id of {request.Id} is not found");

        //Log the operation
        _logger.LogInformation($"Initializing cast deletion/restoration with the id of {cast.Id}, Delete status : {request.Delete}");

        //Delete or restore the cast
        if (request.Delete)
            cast.Delete();
        else
            cast.Restore();

        //Update cast
        _repository.Update(cast);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();

    }
}
