using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Application.Interfaces;
using IPT.TestProject.Application.Models;

namespace IPT.TestProject.Application.Services.Users.Queries.Get
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IList<GetUserModel>>
    {
        private readonly ITestProjectDbContext _testProjectDbContext;

        public GetUserQueryHandler(ITestProjectDbContext testProjectDbContext)
        {
            _testProjectDbContext = testProjectDbContext ?? throw new ArgumentNullException(nameof(testProjectDbContext));
        }

        public async Task<IList<GetUserModel>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {

            return await _testProjectDbContext.Users.AsNoTracking()
               .Include(x => x.UserRoles)
               .ThenInclude(x => x.Role)
               .Select(user => new GetUserModel
               {
                   FirstName = user.FirstName,
                   LastName = user.LastName,
                   Email = user.Email,
                   BirthDate = user.BirthDate,
                   Id = user.Id,
                   UserRoles = user.UserRoles.Select((userRole) => new UserRoleModel
                   {
                       Role = new RoleModel
                       {
                           Id = userRole.Role.Id,
                           Name = userRole.Role.Name
                       }
                   }).ToList()
               }).ToListAsync();
        }
    }
}
