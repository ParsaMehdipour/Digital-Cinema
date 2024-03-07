using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities.States;
public class State : Entity
{

    #region Fields

    public StateName StateName { get; private set; } = null!;

    #endregion

    #region Ctor
    private State() { }

    private State(StateName stateName) => StateName = stateName;

    #endregion

    #region Methods

    public State Create(StateName stateName) => new(stateName);

    public void SetStateName(StateName stateName)
    {
        if (StateName != null! && StateName.Equals(stateName)) return;

        StateName = stateName;
    }

    #endregion
}

