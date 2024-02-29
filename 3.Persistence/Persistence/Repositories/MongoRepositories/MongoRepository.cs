using Domain.Primitives;
using Domain.Repositories.BaseRepositories.MongoRepositories;
using MongoDB.Driver;
using SharedKernel.DataProviderSettings.MongoDB;
using System.Linq.Expressions;

namespace Persistence.Repositories.MongoRepositories;

public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : MongoEntity
{
    private readonly IMongoCollection<TEntity> _collection;

    public MongoRepository(MongoDbDatabaseSettings settings)
    {
        var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
        _collection = database.GetCollection<TEntity>(GetCollectionName(typeof(TEntity)));
    }

    private protected string GetCollectionName(Type entityType)
    {
        return ((BsonCollectionAttribute)entityType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault())?.CollectionName;
    }

    public virtual IQueryable<TEntity> AsQueryable()
    {
        return _collection.AsQueryable();
    }

    public virtual IEnumerable<TEntity> FilterBy(
        Expression<Func<TEntity, bool>> filterExpression)
    {
        return _collection.Find(filterExpression).ToEnumerable();
    }

    public virtual IEnumerable<TProjected> FilterBy<TProjected>(
        Expression<Func<TEntity, bool>> filterExpression,
        Expression<Func<TEntity, TProjected>> projectionExpression)
    {
        return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
    }

    public virtual TEntity FindOne(Expression<Func<TEntity, bool>> filterExpression)
    {
        return _collection.Find(filterExpression).FirstOrDefault();
    }

    public virtual Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterExpression)
    {
        return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
    }

    public virtual TEntity FindById(Guid id)
    {
        var filter = Builders<TEntity>.Filter.Eq(ent => ent.Id, id);
        return _collection.Find(filter).SingleOrDefault();
    }

    public virtual Task<TEntity> FindByIdAsync(Guid id)
    {
        return Task.Run(() =>
        {
            var filter = Builders<TEntity>.Filter.Eq(ent => ent.Id, id);
            return _collection.Find(filter).SingleOrDefaultAsync();
        });
    }

    public virtual void InsertOne(TEntity entity)
    {
        _collection.InsertOne(entity);
    }

    public virtual Task InsertOneAsync(TEntity entity)
    {
        return Task.Run(() => _collection.InsertOneAsync(entity));
    }

    public void InsertMany(ICollection<TEntity> entities)
    {
        _collection.InsertMany(entities);
    }


    public virtual async Task InsertManyAsync(ICollection<TEntity> entities)
    {
        await _collection.InsertManyAsync(entities);
    }

    public void ReplaceOne(TEntity entity)
    {
        var filter = Builders<TEntity>.Filter.Eq(ent => ent.Id, entity.Id);
        _collection.FindOneAndReplace(filter, entity);
    }

    public virtual async Task ReplaceOneAsync(TEntity entity)
    {
        var filter = Builders<TEntity>.Filter.Eq(ent => ent.Id, entity.Id);
        await _collection.FindOneAndReplaceAsync(filter, entity);
    }

    public void DeleteOne(Expression<Func<TEntity, bool>> filterExpression)
    {
        _collection.FindOneAndDelete(filterExpression);
    }

    public Task DeleteOneAsync(Expression<Func<TEntity, bool>> filterExpression)
    {
        return Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
    }

    public void DeleteById(Guid id)
    {
        var filter = Builders<TEntity>.Filter.Eq(ent => ent.Id, id);
        _collection.FindOneAndDelete(filter);
    }

    public Task DeleteByIdAsync(Guid id)
    {
        return Task.Run(() =>
        {
            var filter = Builders<TEntity>.Filter.Eq(ent => ent.Id, id);
            _collection.FindOneAndDeleteAsync(filter);
        });
    }

    public void DeleteMany(Expression<Func<TEntity, bool>> filterExpression)
    {
        _collection.DeleteMany(filterExpression);
    }

    public Task DeleteManyAsync(Expression<Func<TEntity, bool>> filterExpression)
    {
        return Task.Run(() => _collection.DeleteManyAsync(filterExpression));
    }
}