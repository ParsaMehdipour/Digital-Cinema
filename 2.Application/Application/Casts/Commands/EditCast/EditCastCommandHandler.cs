using Domain.Entities.Casts;
using Domain.Repositories;
using Domain.Repositories.UnitOfWork;
using Domain.ValueObjects;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Casts.Commands.EditCast;

/// <summary>
/// Represents the edit cast command handler
/// </summary>
public class EditCastCommandHandler : IRequestHandler<EditCastCommand, Result>
{
    private readonly ICastRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<EditCastCommandHandler> _logger;

    public EditCastCommandHandler(ICastRepository repository, IUnitOfWork unitOfWork, ILogger<EditCastCommandHandler> logger)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    /// <summary>
    /// Handles the edit cast command
    /// </summary>
    /// <param name="request">Request</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>
    /// Returns an async operation
    /// </returns>
    public async Task<Result> Handle(EditCastCommand request, CancellationToken cancellationToken)
    {
        //Get the cast by identifier
        Cast cast = await _repository.GetByIdAsync(cancellationToken, request.Id);

        //If the cast was not found
        if (cast is null)
            throw new KeyNotFoundException($"Fetch failed: Cast with the Id of {request.Id} is not found");

        //Log the operation
        _logger.LogInformation($"Initializing cast edition with the id of {cast.Id}");

        //Create first name
        var createFirstnameResult = FirstName.Create(request.FirstName);

        //If the creation result failed
        if (createFirstnameResult.IsSuccess is false)
            return Result.Fail(createFirstnameResult.Error.Message);

        //Create last name
        var createLastNameResult = LastName.Create(request.LastName);

        //If the creation result failed
        if (createLastNameResult.IsSuccess is false)
            return Result.Fail(createLastNameResult.Error.Message);

        //Create age
        var createAgeResult = Age.Create(request.Age);

        //If the creation result failed
        if (createAgeResult.IsSuccess is false)
            return Result.Fail(createAgeResult.Error.Message);

        //Set age
        cast.SetAge(createAgeResult.Value);

        //Set values
        cast.SetFirstName(createFirstnameResult.Value);
        cast.SetLastName(createLastNameResult.Value);
        cast.SetCastType(request.CastType);
        cast.SetGender(request.Gender);
        cast.SetIsAlive(request.IsAlive);

        //Update cast
        _repository.Update(cast);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
