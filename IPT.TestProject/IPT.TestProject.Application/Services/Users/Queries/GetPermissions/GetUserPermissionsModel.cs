using System.Collections.Generic;
using IPT.TestProject.Application.Models;

namespace IPT.TestProject.Application.Services.Users.Queries.GetPermissions
{
    public class GetUserPermissionsModel
    {
        public IList<UserRoleModel> UserRoles { get; set; } = new List<UserRoleModel>();
    }
}
