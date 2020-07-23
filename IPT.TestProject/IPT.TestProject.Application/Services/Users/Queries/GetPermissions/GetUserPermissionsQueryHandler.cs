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

            var user = await _context.Users
                .AsNoTracking()
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .ThenInclude(x => x.RoleHasPermissions)
                .ThenInclude(x => x.Permission)
                .FirstOrDefaultAsync(x => x.Id == authUserId);

            return user.UserRoles
                .SelectMany(x => x.Role.RoleHasPermissions)
                .Select(x => new GetUserPermissionsModel
                {
                    Id = x.Permission.Id,
                    Name = x.Permission.Name
                }).ToList();
        }
    }
}
