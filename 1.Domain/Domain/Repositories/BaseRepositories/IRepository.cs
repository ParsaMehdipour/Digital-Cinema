using Domain.Primitives;

namespace Domain.Repositories.BaseRepositories;
public interface IRepository<TEntity> : IQueryRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Adds an entity to database
    /// </summary>
    /// <param name="entity"></param>
    void Add(TEntity entity);

    /// <summary>
    /// Adds an entity to database async
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Adds a list of entities to database
    /// </summary>
    /// <param name="entities"></param>
    void AddRange(IEnumerable<TEntity> entities);

    /// <summary>
    /// Adds a list of entities to database async
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an entity
    /// </summary>
    /// <param name="entity"></param>
    void Update(TEntity entity);

    /// <summary>
    /// Updates a list of entities
    /// </summary>
    /// <param name="entities"></param>
    void UpdateRange(List<TEntity> entities);


    /// <summary>
    /// Deletes an entity
    /// </summary>
    /// <param name="entity"></param>
    void Delete(TEntity entity);
}
