using Domain.Primitives;

namespace Domain.Repositories.BaseRepositories;
public interface IRepository<TEntity> : IQueryRepository<TEntity> where TEntity : Entity
{
    void Add(TEntity entity);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);

    void AddRange(IEnumerable<TEntity> entities);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

    void Update(TEntity entity);
    void UpdateRange(List<TEntity> entities);

    void Delete(TEntity entity);
}
