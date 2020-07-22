using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPT.TestProject.Application.Services.Users.Queries.GetPermissions
{
    public class GetUserPermissionsQuery : IRequest<IList<GetUserPermissionsModel>>
    {
    }
}
