using Domain.Entities.Casts;
using Domain.Repositories;
using Domain.Repositories.UnitOfWork;
using Domain.ValueObjects;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Casts.Commands.CreateCast;

/// <summary>
/// Represents the handler for create cast command
/// </summary>
public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand, Result<Guid>>
{
    private readonly ICastRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CreateCastCommandHandler> _logger;

    public CreateCastCommandHandler(ICastRepository repository, IUnitOfWork unitOfWork, ILogger<CreateCastCommandHandler> logger)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    /// <summary>
    /// Handle method
    /// </summary>
    /// <param name="request">Create cast command send from the user</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Task returns an asynchronous result
    /// The result contains the id of the created cast
    /// </returns>
    public async Task<Result<Guid>> Handle(CreateCastCommand request, CancellationToken cancellationToken)
    {
        //Log the operation
        _logger.LogInformation($"Inserting the cast into database with the fallowing information : {request.FirstName}, {request.LastName}, {request.Gender} ...");

        //Create first name value object
        var createFirstNameResult = FirstName.Create(request.FirstName);

        //If there were any errors
        if (createFirstNameResult.IsSuccess is false)
            return Result.Fail(createFirstNameResult.Error.Message);

        //Crate last name value object
        var createLastName = LastName.Create(request.LastName);

        if (createLastName.IsSuccess is false)
            return Result.Fail(createLastName.Error.Message);

        //Create a null age to set later in code
        Age? age = null;

        if (request.Age is not null)
        {
            //Create age value object
            var createAgeResult = Age.Create(request.Age.Value);

            if (createAgeResult.IsSuccess is false)
                return Result.Fail(createAgeResult.Error.Message);

            //Set age
            age = createAgeResult.Value;
        }

        //Create cast
        var cast = Cast.Create(createFirstNameResult.Value, createLastName.Value, request.Gender, request.CastType, request.IsAlive, age);

        //Insertion
        await _repository.AddAsync(cast, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(cast.Id);
    }
}
