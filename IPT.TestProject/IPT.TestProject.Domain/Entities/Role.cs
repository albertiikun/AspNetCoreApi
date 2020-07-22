using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace IPT.TestProject.Domain.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public ICollection<RoleHasPermission> RoleHasPermissions { get; set; }

    }
}
