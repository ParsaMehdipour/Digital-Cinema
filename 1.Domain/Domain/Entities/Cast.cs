using Domain.Enums;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;
public class Cast : Entity
{
    #region Ctor

    private Cast(Guid id, FirstName firstName, LastName lastName, Gender gender, CastType castType, bool isAlive, Age? age = null) : base(id)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetGender(gender);
        SetCastType(castType);
        SetIsAlive(isAlive);

        if (isAlive)
            SetAge(age);
    }

    private Cast()
    {

    }

    #endregion

    #region Fields

    public FirstName FirstName { get; private set; } = null!;

    public LastName LastName { get; private set; } = null!;

    public bool IsAlive { get; private set; }

    public Age? Age { get; private set; }

    public Gender Gender { get; private set; }

    public CastType CastType { get; private set; }

    #endregion

    #region Methods

    public Cast Create(Guid id, FirstName firstName, LastName lastName, Gender gender, CastType castType, bool isAlive, Age? age = null) => new(id, firstName, lastName, gender, castType, isAlive, age);

    public void SetFirstName(FirstName firstName) => FirstName = firstName;

    public void SetLastName(LastName lastName) => LastName = lastName;

    public void SetIsAlive(bool isAlive) => IsAlive = isAlive;

    public void SetAge(Age? age = null) => Age = age;

    public void SetGender(Gender gender) => Gender = gender;

    public void SetCastType(CastType castType) => CastType = castType;

    #endregion
}
