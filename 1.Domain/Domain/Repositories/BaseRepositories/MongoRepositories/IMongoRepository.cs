using Domain.Primitives;
using System.Linq.Expressions;

namespace Domain.Repositories.BaseRepositories.MongoRepositories;
public interface IMongoRepository<TEntity> where TEntity : MongoEntity
{
    IQueryable<TEntity> AsQueryable();

    IEnumerable<TEntity> FilterBy(
        Expression<Func<TEntity, bool>> filterExpression);

    IEnumerable<TProjected> FilterBy<TProjected>(
        Expression<Func<TEntity, bool>> filterExpression,
        Expression<Func<TEntity, TProjected>> projectionExpression);

    TEntity FindOne(Expression<Func<TEntity, bool>> filterExpression);

    Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterExpression);

    TEntity FindById(Guid id);

    Task<TEntity> FindByIdAsync(Guid id);

    void InsertOne(TEntity entity);

    Task InsertOneAsync(TEntity entity);

    void InsertMany(ICollection<TEntity> entities);

    Task InsertManyAsync(ICollection<TEntity> entities);

    void ReplaceOne(TEntity entity);

    Task ReplaceOneAsync(TEntity entity);

    void DeleteOne(Expression<Func<TEntity, bool>> filterExpression);

    Task DeleteOneAsync(Expression<Func<TEntity, bool>> filterExpression);

    void DeleteById(Guid id);

    Task DeleteByIdAsync(Guid id);

    void DeleteMany(Expression<Func<TEntity, bool>> filterExpression);

    Task DeleteManyAsync(Expression<Func<TEntity, bool>> filterExpression);
}
