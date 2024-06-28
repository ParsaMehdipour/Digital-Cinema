using Domain.Primitives;
using System.Linq.Expressions;

namespace Domain.Repositories.BaseRepositories;
public interface IQueryRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// List of <see cref="TEntity"/> by no tracking and filters by the given predicate
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// List of <see cref="TEntity"/> by no tracking
    /// </summary>
    /// <returns></returns>
    IQueryable<TEntity> Get();

    /// <summary>
    /// Finds item in <see cref="TEntity"/> by tracking.
    /// </summary>
    /// <returns></returns>
    TEntity GetById(params object[] ids);

    /// <summary>
    /// Finds async item in <see cref="TEntity"/> by tracking.
    /// </summary>
    /// <returns></returns>
    ValueTask<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);

    /// <summary>
    /// Ignores query filters
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TEntity?> GetWithoutQueryFilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    /// <summary>
    /// Exists this <see cref="TEntity"/> in database by no tracking.
    /// </summary>
    /// <returns></returns>
    Task<bool> ExistsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Exists async this <see cref="TEntity"/> in database by no tracking.
    /// </summary>
    /// <returns></returns>
    bool Exists();

    /// <summary>
    /// Exists this <see cref="TEntity"/> in database by no tracking.
    /// </summary>
    /// <returns></returns>
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    /// <summary>
    /// Exists async this <see cref="TEntity"/> in database by no tracking.
    /// </summary>
    /// <returns></returns>
    bool Exists(Expression<Func<TEntity, bool>> predicate);
}
