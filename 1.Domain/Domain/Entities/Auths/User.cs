﻿using Domain.Primitives;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Auths;

public class User : IdentityUser<Guid>, IAuditableEntity
{
    //AuditableEntity
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public bool IsDeleted { get; set; }
}
