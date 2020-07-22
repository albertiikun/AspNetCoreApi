using MediatR;
using System;
using IPT.TestProject.Domain.Entities;

namespace IPT.TestProject.Application.Services.Users.Commands.Add
{
    public class AddUserCommand : IRequest<Unit>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid Role_Id { get; set; }
          
        public DateTime BirthDate { get; set; }

        public User AddUser()
        {
            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                BirthDate = BirthDate,
                UserName = Email
            };
        }
    }
}
