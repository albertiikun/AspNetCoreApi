using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Application.Interfaces;
using IPT.TestProject.Application.Models;

namespace IPT.TestProject.Application.Services.Categories.Queries.Get
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IList<GetCategoriesModel>>
    {
        private readonly ITestProjectDbContext _context;
        public GetCategoriesQueryHandler(ITestProjectDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IList<GetCategoriesModel>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Categories.Select(ctg => new GetCategoriesModel
            {
                Id = ctg.Id,
                Name = ctg.Name,
                Movies = ctg.Movies.Select(movies => new MovieModel
                {
                    Id = movies.Id,
                    Name = movies.Name
                }).ToList()
            }).ToListAsync();
        }
    }
}
