using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Application.Interfaces;
using IPT.TestProject.Domain.Entities;

namespace IPT.TestProject.Application.Services.Permissions.Commands.Assign
{
    public class AssignPermissionCommnadHandler : IRequestHandler<AssignPermissionCommand, Unit>
    {
        private readonly ITestProjectDbContext _context;

        public AssignPermissionCommnadHandler(ITestProjectDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(AssignPermissionCommand request, CancellationToken cancellationToken)
        {
            var roleHasPermission = new RoleHasPermission
            {
                PermissionId = request.Permission_Id,
                RoleId = request.Role_Id
            };

            await _context.RoleHasPermission.AddAsync(roleHasPermission);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
