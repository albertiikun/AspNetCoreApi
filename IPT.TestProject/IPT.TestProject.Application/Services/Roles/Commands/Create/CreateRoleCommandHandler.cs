using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Domain.Entities;

namespace IPT.TestProject.Application.Services.Roles.Commands.Create
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Unit>
    {
        private readonly RoleManager<Role> _roleManager;

        public CreateRoleCommandHandler(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleManager.CreateAsync(new Role
            {
                Name = request.Name
            });

            return Unit.Value;
        }
    }
}
