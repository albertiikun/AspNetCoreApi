using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPT.TestProject.Application.Services.Roles.Queries.Get
{
    public class GetRoleQuery : IRequest<IList<GetRoleModel>>
    {
    }
}
