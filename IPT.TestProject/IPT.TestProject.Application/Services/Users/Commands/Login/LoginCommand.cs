using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPT.TestProject.Application.Services.Users.Commands.Login
{
    public class LoginCommand : IRequest<LoginModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
