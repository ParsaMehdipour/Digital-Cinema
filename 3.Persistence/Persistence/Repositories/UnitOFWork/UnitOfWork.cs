using Domain.Primitives;
using Domain.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Persistence.Repositories.UnitOFWork;

/// <summary>
/// Represents the unit of work
/// </summary>
/// <param name="context"></param>
public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    #region .:: TRANSACTIONS ::.

    public async Task BeginTransaction(CancellationToken ct)
    {
        await context.Database.BeginTransactionAsync(ct);
    }

    public async Task BeginTransaction(IsolationLevel isolationLevel, CancellationToken ct)
    {
        await context.Database.BeginTransactionAsync(isolationLevel, ct);
    }

    public async Task CommitTransaction(CancellationToken ct)
    {
        await context.Database.CommitTransactionAsync(ct);
    }

    public async Task RollbackTransaction(CancellationToken ct)
    {
        await context.Database.RollbackTransactionAsync(ct);
    }

    #endregion

    #region .:: SAVE CHANGES ::.

    public async Task<int> SaveChangesAsync(CancellationToken ct)
    {
        Save();

        return await context.SaveChangesAsync(ct);
    }

    public async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken ct = new())
    {
        Save();

        return await context.SaveChangesAsync(acceptAllChangesOnSuccess, ct);
    }

    private void Save()
    {

        foreach (var entry in context.ChangeTracker.Entries())
        {
            if (entry.Entity is not Entity entity)
                throw new Exception("please add IAuditable to entity");

            switch (entry.State)
            {
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    if (entity.IsDeleted)
                        break;
                    entry.State = EntityState.Modified;
                    entity.IsDeleted = true;
                    break;
                case EntityState.Modified:
                    entity.ModifiedOnUtc = DateTime.UtcNow;
                    break;
                case EntityState.Added:
                    entity.CreatedOnUtc = DateTime.UtcNow;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("", entry.State, "");
            }
        }
    }

    #endregion
}