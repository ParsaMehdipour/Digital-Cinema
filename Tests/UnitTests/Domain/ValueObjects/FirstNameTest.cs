using Domain.Shared;
using Domain.ValueObjects;
using static Xunit.Assert;

namespace UnitTests.Domain.ValueObjects;

public class FirstNameTest
{
    [Fact]
    public void FirstNameInitialization_ReturnsSuccess_WhenPassedValueIsValid()
    {
        //Act
        Result<FirstName> testFirstNameResult = FirstName.Create("Parsa");

        //Assert
        True(testFirstNameResult.IsSuccess);
        False(testFirstNameResult.IsFailure);
    }

    [Fact]
    public void FirstNameInitialization_ReturnsFailedResult_WhenPassedValueIsTooLong()
    {
        //Act
        Result<FirstName> testFirstNameResult = FirstName.Create("kgosmntccgztecosktifnzrbhqtbjxmxylomrujltypxmbaoqauymvdwosmyvcmxzlhkebatrsnbhywxkotmxgjuxnr");

        //Assert
        True(testFirstNameResult.IsFailure);
        False(testFirstNameResult.IsSuccess);
    }
}
