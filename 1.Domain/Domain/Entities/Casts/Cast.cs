using Domain.Enums;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities.Casts;
public class Cast : Entity
{
    #region Ctor

    private Cast(FirstName firstName, LastName lastName, Gender gender, CastType castType, bool isAlive, Age age)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetGender(gender);
        SetCastType(castType);
        SetIsAlive(isAlive);
        SetAge(age);
    }

    private Cast()
    {

    }

    #endregion

    #region Fields

    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public bool IsAlive { get; private set; }

    public Age Age { get; private set; }

    public Gender Gender { get; private set; }

    public CastType CastType { get; private set; }

    #endregion

    #region Methods

    public static Cast Create(FirstName firstName, LastName lastName, Gender gender, CastType castType, bool isAlive, Age age) => new(firstName, lastName, gender, castType, isAlive, age);

    public void SetFirstName(FirstName firstName)
    {
        if (FirstName != null && FirstName.Equals(firstName)) return;

        FirstName = firstName;
    }

    public void SetLastName(LastName lastName)
    {
        if (LastName != null && LastName.Equals(lastName)) return;

        LastName = lastName;
    }

    public void SetIsAlive(bool isAlive)
    {
        if (IsAlive.Equals(isAlive)) return;

        IsAlive = isAlive;
    }

    public void SetAge(Age age)
    {
        if (Age != null && Age.Equals(age)) return;

        Age = age;
    }

    public void SetGender(Gender gender)
    {
        if (Gender.Equals(gender)) return;

        Gender = gender;
    }

    public void SetCastType(CastType castType)
    {
        if (CastType.Equals(castType)) return;

        CastType = castType;
    }

    #endregion
}
