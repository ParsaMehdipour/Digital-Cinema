namespace Domain.Primitives;
public interface IAuditableEntity
{
    DateTime CreatedOnUtc { get; set; }
    DateTime? ModifiedOnUtc { get; set; }
    public bool IsDeleted { get; set; }
}
