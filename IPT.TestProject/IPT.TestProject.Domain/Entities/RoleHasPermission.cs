using System;
using System.Collections.Generic;

namespace IPT.TestProject.Domain.Entities
{
    public class RoleHasPermission
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public Guid PermissionId { get; set; }

        public Role Role { get; set; }

        public Permission Permission { get; set; }
    }
}