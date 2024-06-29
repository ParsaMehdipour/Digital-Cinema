using Domain.Entities.Casts;
using Domain.Enums;
using Domain.ValueObjects;
using static Xunit.Assert;

namespace UnitTests.Domain.Casts;

public class CastTests
{
    private readonly string _testFirstName = "test first name";
    private readonly string _testLastName = "test last name";
    private readonly int _testAge = 23;
    private readonly Gender _testGender = Gender.Male;
    private readonly CastType _testCastType = CastType.ActorActress;
    private readonly bool _testIsAlive = true;

    private Cast CreateCast()
    {
        var firstNameResult = FirstName.Create(_testFirstName);
        var lastNameResult = LastName.Create(_testLastName);
        var ageResult = Age.Create(_testAge);
        return Cast.Create(firstNameResult.Value, lastNameResult.Value, _testGender, _testCastType, _testIsAlive, ageResult.Value);
    }

    [Fact]
    public void ValueInitialization_ReturnsCast_WhenPassedValuesAreValid()
    {
        //Arrange
        Cast? testCast = null;

        //Act
        testCast = CreateCast();

        //Assert
        Equal(_testFirstName, testCast.FirstName.Value);
        Equal(_testLastName, testCast.LastName.Value);
        Equal(_testAge, testCast.Age.Value);
        Equal(_testGender, testCast.Gender);
        Equal(_testCastType, testCast.CastType);
        Equal(_testIsAlive, testCast.IsAlive);
    }

    [Fact]
    public void AgeEdition_ChangesValue_WhenPassedAgeIsValid()
    {
        //Arrange
        Cast? testCast = null;

        testCast = CreateCast();

        //Act
        testCast.SetAge(Age.Create(25).Value);

        //Assert
        Equal(25, testCast.Age.Value);
    }

    [Fact]
    public void AgeEdition_DoesNotChangeValue_WhenPassedAgeIsTheSame()
    {
        //Arrange
        Cast? testCast = null;

        testCast = CreateCast();

        //Act
        testCast.SetAge(Age.Create(23).Value);

        //Assert
        Equal(23, testCast.Age.Value);
    }
}
