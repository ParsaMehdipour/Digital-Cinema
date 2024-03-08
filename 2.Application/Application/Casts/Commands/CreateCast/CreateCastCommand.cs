using Domain.Enums;
using FluentResults;
using MediatR;

namespace Application.Casts.Commands.CreateCast;

public record CreateCastCommand(string FirstName, string LastName, CastType CastType, Gender Gender, bool IsAlive, int? Age) : IRequest<Result<Guid>>;
