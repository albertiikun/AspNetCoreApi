using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPT.TestProject.Application.Services.Roles.Commands.Create
{
    public class CreateRoleCommand : IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
