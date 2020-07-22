using System;
using System.Collections.Generic;
using IPT.TestProject.Application.Models;
using IPT.TestProject.Domain.Entities;

namespace IPT.TestProject.Application.Services.Users.Queries.Get
{
    public class GetUserModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public IList<UserRoleModel> UserRoles { get; set; } = new List<UserRoleModel>();
    }
}
