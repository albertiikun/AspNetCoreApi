using System;
using System.Collections.Generic;

namespace IPT.TestProject.Application.Models
{
    public class RoleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IList<RoleHasPermissionModel> RoleHasPermissions { get; set; } = new List<RoleHasPermissionModel>();
    }
}
