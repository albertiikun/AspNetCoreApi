using MediatR;
using System;

namespace IPT.TestProject.Application.Services.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
