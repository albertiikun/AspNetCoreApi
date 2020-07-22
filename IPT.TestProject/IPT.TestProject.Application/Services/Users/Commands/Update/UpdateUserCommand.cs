using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPT.TestProject.Application.Services.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
