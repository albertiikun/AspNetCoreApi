using MediatR;
using System;
using System.Collections.Generic;

namespace IPT.TestProject.Application.Services.Permissions.Queries.Get
{
    public class GetPermissionsModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}