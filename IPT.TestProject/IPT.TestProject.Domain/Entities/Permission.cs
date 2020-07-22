using System;
using System.Collections.Generic;
using System.Text;
using IPT.TestProject.Domain.Entities.Base;

namespace IPT.TestProject.Domain.Entities
{
    public class Permission : Entity
    {
        public Permission()
        {
            RoleHasPermissions = new HashSet<RoleHasPermission>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<RoleHasPermission> RoleHasPermissions { get; set; }

    }
}
