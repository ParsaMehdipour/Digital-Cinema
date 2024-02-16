using Domain.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Persistence;


/// <remarks>
/// Add migrations using the following command inside the 'Persistence' project directory:
///
/// dotnet ef migrations add --startup-project WebApi --context ApplicationDdContext [migration-name]
/// </remarks>
public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
