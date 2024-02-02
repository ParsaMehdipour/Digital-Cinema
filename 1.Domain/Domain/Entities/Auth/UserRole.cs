using Domain.Primitives;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Auth;
public class UserRole : IdentityUserRole<Guid>, IAuditableEntity
{
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public bool IsDeleted { get; set; }
}
