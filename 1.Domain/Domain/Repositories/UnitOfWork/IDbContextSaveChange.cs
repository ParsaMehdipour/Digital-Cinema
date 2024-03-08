namespace Domain.Repositories.UnitOfWork;

public interface IDbContextSaveChange
{
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken ct);

    Task<int> SaveChangesAsync(CancellationToken ct);
}