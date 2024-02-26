using Domain.Repositories.BaseRepositories.MongoRepositories;

namespace Domain.Repositories.DomainEvent;

public interface IDomainEventRepository : IMongoRepository<DomainEvents.DomainEvent>
{
}
