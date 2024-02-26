using Domain.Primitives;
using System.Linq.Expressions;

namespace Domain.Repositories.BaseRepositories.MongoRepositories;
public interface IMongoRepository<TEntity> where TEntity : Entity
{
    IQueryable<TEntity> AsQueryable();

    IEnumerable<TEntity> FilterBy(
        Expression<Func<TEntity, bool>> filterExpression);

    IEnumerable<TProjected> FilterBy<TProjected>(
        Expression<Func<TEntity, bool>> filterExpression,
        Expression<Func<TEntity, TProjected>> projectionExpression);

    TEntity FindOne(Expression<Func<TEntity, bool>> filterExpression);

    Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterExpression);

    TEntity FindById(string id);

    Task<TEntity> FindByIdAsync(string id);

    void InsertOne(TEntity document);

    Task InsertOneAsync(TEntity document);

    void InsertMany(ICollection<TEntity> documents);

    Task InsertManyAsync(ICollection<TEntity> documents);

    void ReplaceOne(TEntity document);

    Task ReplaceOneAsync(TEntity document);

    void DeleteOne(Expression<Func<TEntity, bool>> filterExpression);

    Task DeleteOneAsync(Expression<Func<TEntity, bool>> filterExpression);

    void DeleteById(string id);

    Task DeleteByIdAsync(string id);

    void DeleteMany(Expression<Func<TEntity, bool>> filterExpression);

    Task DeleteManyAsync(Expression<Func<TEntity, bool>> filterExpression);
}
