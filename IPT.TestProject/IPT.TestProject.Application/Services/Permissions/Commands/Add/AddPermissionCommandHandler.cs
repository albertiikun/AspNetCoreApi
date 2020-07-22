using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Application.Interfaces;
using IPT.TestProject.Domain.Entities;

namespace IPT.TestProject.Application.Services.Permissions.Commands.Add
{
    public class AddPermissionCommandHandler : IRequestHandler<AddPermissionCommand, Unit>
    {
        private readonly ITestProjectDbContext _context;

        public AddPermissionCommandHandler(ITestProjectDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(AddPermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = new Permission
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };

            await _context.Permissions.AddAsync(permission);
           
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
