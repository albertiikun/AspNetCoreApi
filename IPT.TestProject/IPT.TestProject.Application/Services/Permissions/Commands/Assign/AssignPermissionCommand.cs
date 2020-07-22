using MediatR;
using System;

namespace IPT.TestProject.Application.Services.Permissions.Commands.Assign
{
    public class AssignPermissionCommand : IRequest<Unit>
    {
        public Guid Role_Id { get; set; }

        public Guid Permission_Id { get; set; }
    }
}
