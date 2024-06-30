using Application.Casts.Commands.CreateCast;
using Domain.Enums;
using Domain.Errors;
using Domain.Repositories;
using Domain.Repositories.UnitOfWork;
using Microsoft.Extensions.Logging;
using Moq;
using static Xunit.Assert;

namespace UnitTests.Application.Casts.Commands;

public class CreateCastTests
{
    private readonly Mock<ICastRepository> _repositoryMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<ILogger<CreateCastCommandHandler>> _loggerMock = new();
    private readonly CreateCastCommandHandler _systemUnderTest;

    public CreateCastTests()
    {
        _systemUnderTest = new(_repositoryMock.Object, _unitOfWorkMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task CreateCasts_ReturnsFailedResult_WhenPassedFirstNameIsTooLong()
    {
        //Arrange
        CreateCastCommand command = new(FirstName: "kgosmntccgztecosktifnzrbhqtbjxmxylomrujltypxmbaoqauymvdwosmyvcmxzlhkebatrsnbhywxkotmxgjuxnr",
            LastName: "Test",
            Age: 23,
            CastType: CastType.ActorActress,
            Gender: Gender.Male,
            IsAlive: true);

        //Act
        var result = await _systemUnderTest.Handle(command, CancellationToken.None);

        //Assert
        False(result.IsSuccess);
        True(result.IsFailed);
        Equal(DomainErrors.FirstName.TooLong.Message, result.Errors.FirstOrDefault()!.Message);
    }
}
