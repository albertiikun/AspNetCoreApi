using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Application.Helpers;
using IPT.TestProject.Application.Interfaces;
using IPT.TestProject.Application.Models;

namespace IPT.TestProject.Application.Services.Users.Queries.GetPermissions
{
    public class GetUserPermissionsQueryHandler : IRequestHandler<GetUserPermissionsQuery, IList<GetUserPermissionsModel>>
    {
        private readonly ITestProjectDbContext _context;

        public GetUserPermissionsQueryHandler(ITestProjectDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));       
        }

        public async Task<IList<GetUserPermissionsModel>> Handle(GetUserPermissionsQuery request, CancellationToken cancellationToken)
        {
            var authUserId = UserHelper.AuthId();

            return await _context.Users.Where(x => x.Id == authUserId).Select(user => new GetUserPermissionsModel
            {
                UserRoles = user.UserRoles.Select((userRole) => new UserRoleModel
                {
                    Role = new RoleModel
                    {
                        Id = userRole.Role.Id,
                        Name = userRole.Role.Name,
                        RoleHasPermissions = userRole.Role.RoleHasPermissions.Select(roleHasPermission => new RoleHasPermissionModel
                        {
                            Permission = new PermissionModel
                            {
                                Id = roleHasPermission.Permission.Id,
                                Name = roleHasPermission.Permission.Name
                            }
                        }).ToList()
                    }
                }).ToList()
            }).ToListAsync();
        }
    }
}
