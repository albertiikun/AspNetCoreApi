using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPT.TestProject.Application.Services.Permissions.Queries.Get
{
    public class GetPermissionsQuery : IRequest<IList<GetPermissionsModel>>
    {
    }
}
