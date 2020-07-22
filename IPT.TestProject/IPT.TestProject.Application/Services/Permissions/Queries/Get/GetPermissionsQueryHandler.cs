using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Application.Interfaces;

namespace IPT.TestProject.Application.Services.Permissions.Queries.Get
{
    public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, IList<GetPermissionsModel>>
    {
        private readonly ITestProjectDbContext _context;

        public GetPermissionsQueryHandler(ITestProjectDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IList<GetPermissionsModel>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Permissions.AsNoTracking().Select(permission => new GetPermissionsModel
            {
                Id = permission.Id,
                Name = permission.Name
            }).ToListAsync();
        }
    }
}
