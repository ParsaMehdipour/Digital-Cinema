using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Genre : Entity
{
    #region Fields

    public Title Title { get; private set; } = null!;

    #endregion

    #region Ctor

    private Genre(Guid id, Title title) : base(id) => SetTitle(title);

    #endregion

    #region Methods

    public Genre Create(Guid id, Title title) => new(id, title);

    public void SetTitle(Title title) => Title = title;

    #endregion
}
