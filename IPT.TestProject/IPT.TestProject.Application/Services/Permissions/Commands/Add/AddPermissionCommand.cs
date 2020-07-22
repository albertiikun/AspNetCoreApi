using MediatR;

namespace IPT.TestProject.Application.Services.Permissions.Commands.Add
{
    public class AddPermissionCommand : IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
