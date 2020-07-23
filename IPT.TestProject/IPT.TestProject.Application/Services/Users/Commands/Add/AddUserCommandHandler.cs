using IPT.TestProject.Application.Interfaces;
using IPT.TestProject.Domain.Entities;
using IPT.TestProject.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace IPT.TestProject.Application.Services.Users.Commands.Add
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Unit>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITestProjectDbContext _context;

        public AddUserCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager, ITestProjectDbContext context)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.AddUser();

            var role = await _roleManager.FindByIdAsync(request.Role_Id.ToString());

            if (role == null) throw new Exception("Role do not exists");

            await _userManager.CreateAsync(user, request.Password);

            await _userManager.AddToRoleAsync(user, role.Name);

            await CreateUserClaims(user,role);

            return Unit.Value;
        }

        private async Task CreateUserClaims(User user,Role role)
        {
            string unknown = "N/A";

            var claimName = new UserClaimEnum();

            var getUser = await _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .ThenInclude(x => x.RoleHasPermissions)
                .ThenInclude(x => x.Permission)
                .FirstOrDefaultAsync(x => x.Id == user.Id);

            var permission = getUser.UserRoles.SelectMany(x => x.Role.RoleHasPermissions).Select(x => x.Permission.Name).Distinct().ToArray();

          
            var claims = new List<Claim>
            {
                new Claim(claimName.UserId, user.Id.ToString() ?? unknown),
                new Claim(claimName.Email, user.Email ?? unknown),
                new Claim(claimName.FirstName, user.FirstName ?? unknown),
                new Claim(claimName.LastName, user.LastName ?? unknown),
                new Claim(claimName.RoleName, role.Name ?? unknown),
                new Claim(claimName.RoleId, role.Id.ToString() ?? unknown),
                new Claim(claimName.PermissionName, JsonConvert.SerializeObject(permission) ?? unknown)
            };

            await _userManager.AddClaimsAsync(user, claims);
        }
    }
}
