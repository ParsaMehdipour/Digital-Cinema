using Domain.Primitives;
using Domain.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories.PostgressRepositories;

public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : Entity
{
    protected DbSet<TEntity> Entities { get; }
    protected IQueryable<TEntity> Table => Entities;
    protected IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

    protected DbContext Context { get; }

    public QueryRepository(DbContext context)
    {
        Context = context;
        Entities = Context.Set<TEntity>();
    }


    /// <summary>
    /// List of <see cref="TEntity"/> by no tracking and filters by the given predicate
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
    {
        return TableNoTracking.Where(predicate);
    }

    /// <summary>
    /// List of <see cref="TEntity"/> by no tracking
    /// </summary>
    /// <returns></returns>
    public IQueryable<TEntity> Get()
    {
        return TableNoTracking;
    }

    /// <summary>
    /// Finds item in <see cref="TEntity"/> by tracking.
    /// </summary>
    /// <returns></returns>
    public virtual TEntity GetById(params object[] ids)
    {
        return Entities.Find(ids);
    }

    /// <summary>
    /// Finds async item in <see cref="TEntity"/> by tracking.
    /// </summary>
    /// <returns></returns>
    public virtual ValueTask<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
    {
        return Entities.FindAsync(ids, cancellationToken);
    }

    /// <summary>
    /// Ignores query filters
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<TEntity?> GetWithoutQueryFilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await Entities.IgnoreQueryFilters().SingleOrDefaultAsync(predicate, cancellationToken);
    }

    /// <summary>
    /// Exists this <see cref="TEntity"/> in database by no tracking.
    /// </summary>
    /// <returns></returns>
    public virtual bool Exists()
    {
        return TableNoTracking.Any();
    }

    /// <summary>
    /// Exists async this <see cref="TEntity"/> in database by no tracking.
    /// </summary>
    /// <returns></returns>
    public virtual async Task<bool> ExistsAsync(CancellationToken cancellationToken)
    {
        return await TableNoTracking.AnyAsync(cancellationToken);
    }

    /// <summary>
    /// Exists this <see cref="TEntity"/> in database by no tracking.
    /// </summary>
    /// <returns></returns>
    public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
    {
        return TableNoTracking.Any(predicate);
    }

    /// <summary>
    /// Exists async this <see cref="TEntity"/> in database by no tracking.
    /// </summary>
    /// <returns></returns>
    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await TableNoTracking.AnyAsync(predicate, cancellationToken);
    }
}