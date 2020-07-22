using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using IPT.TestProject.Domain.Entities.Base;

namespace IPT.TestProject.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
