using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Application.Interfaces;
using IPT.TestProject.Application.Models;

namespace IPT.TestProject.Application.Services.Movies.Queries.Get
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IList<GetMoviesModel>>
    {
        private readonly ITestProjectDbContext _context;

        public GetMoviesQueryHandler(ITestProjectDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async  Task<IList<GetMoviesModel>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Movies.Include(x => x.Category).Select(movies => new GetMoviesModel
            {
                Id = movies.Id,
                Name = movies.Name,
                Category_id = movies.Category_Id,
                CategoryModel = new CategoryModel
                {
                    Id = movies.Category.Id,
                    Name = movies.Category.Name
                }
            }).ToListAsync();
        }
    }
}
