using Domain.Entities.Tickets;
using Domain.Repositories.BaseRepositories;

namespace Domain.Repositories;
public interface ITicketRepository : IRepository<Ticket>
{
}
