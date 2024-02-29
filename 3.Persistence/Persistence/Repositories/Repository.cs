using Domain.Primitives;
using Domain.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class Repository<TEntity> : QueryRepository<TEntity>, IRepository<TEntity>
    where TEntity : Entity
{
    public Repository(DbContext context) : base(context)
    {
    }

    /// <summary>
    /// Adds an entity to database
    /// </summary>
    /// <param name="entity"></param>
    public virtual void Add(TEntity entity)
    {
        Entities.Add(entity);
    }

    /// <summary>
    /// Adds an entity to database async
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await Entities.AddAsync(entity, cancellationToken);
    }

    /// <summary>
    /// Adds a list of entities to database
    /// </summary>
    /// <param name="entities"></param>
    public virtual void AddRange(IEnumerable<TEntity> entities)
    {
        Entities.AddRange(entities);
    }

    /// <summary>
    /// Adds a list of entities to database async
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await Entities.AddRangeAsync(entities, cancellationToken);
    }

    /// <summary>
    /// Updates an entity
    /// </summary>
    /// <param name="entity"></param>
    public virtual void Update(TEntity entity)
    {
        Entities.Update(entity);
    }

    /// <summary>
    /// Updates a list of entities
    /// </summary>
    /// <param name="entities"></param>
    public virtual void UpdateRange(List<TEntity> entities)
    {
        Entities.UpdateRange(entities);
    }

    /// <summary>
    /// Deletes an entity
    /// </summary>
    /// <param name="entity"></param>
    public void Delete(TEntity entity)
    {
        Entities.Remove(entity);
    }
}