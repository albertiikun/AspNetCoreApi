using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using IPT.TestProject.Application.Models;
using IPT.TestProject.Domain.Entities;

namespace IPT.TestProject.Application.Services.Users.Queries.Get
{
    public class GetUserQuery : IRequest<IList<GetUserModel>>
    {
    }
}
