using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Domain.Entities;

namespace IPT.TestProject.Application.Services.Roles.Queries.Get
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, IList<GetRoleModel>>
    {
        private readonly RoleManager<Role> _roleManager;

        public GetRoleQueryHandler(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        public async Task<IList<GetRoleModel>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            return await _roleManager.Roles.AsNoTracking().Select(role => new GetRoleModel
            {
                Id = role.Id,
                Name = role.Name
            }).ToListAsync();
        }
    }
}
