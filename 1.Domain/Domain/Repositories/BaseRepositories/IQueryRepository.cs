using Domain.Primitives;
using System.Linq.Expressions;

namespace Domain.Repositories.BaseRepositories;
public interface IQueryRepository<TEntity> where TEntity : Entity
{
    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> Get();

    TEntity GetById(params object[] ids);
    ValueTask<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
    Task<TEntity> GetWithoutQueryFilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(CancellationToken cancellationToken);
    bool IsExists();

    Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    bool IsExists(Expression<Func<TEntity, bool>> predicate);
}
