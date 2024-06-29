using Domain.Shared;
using Domain.ValueObjects;

namespace UnitTests.Domain.ValueObjects;
using static Xunit.Assert;

public class AgeTests
{
    [Fact]
    public void AgeInitialization_ReturnsSuccessResult_WhenPassedValueIsValid()
    {
        //Act
        Result<Age> testAgeResult = Age.Create(23);

        //Assert
        True(testAgeResult.IsSuccess);
        False(testAgeResult.IsFailure);
    }


    [Fact]
    public void AgeInitialization_ReturnsFailedResult_WhenPassedValueIsNotValid()
    {
        //Act
        Result<Age> testAgeResult = Age.Create(-1);

        //Assert
        True(testAgeResult.IsFailure);
        False(testAgeResult.IsSuccess);
    }
}
