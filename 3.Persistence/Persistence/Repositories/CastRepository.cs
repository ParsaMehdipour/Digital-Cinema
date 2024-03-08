using Domain.Entities.Casts;
using Domain.Repositories;
using Persistence.Repositories.PostgressRepositories;

namespace Persistence.Repositories;
public class CastRepository : Repository<Cast>, ICastRepository
{
    public CastRepository(ApplicationDbContext context) : base(context)
    {
    }
}
