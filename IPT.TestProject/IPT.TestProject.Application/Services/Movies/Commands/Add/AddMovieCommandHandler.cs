using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Application.Interfaces;
using IPT.TestProject.Domain.Entities;

namespace IPT.TestProject.Application.Services.Movies.Commands.Add
{
    public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, Unit>
    {
        private readonly ITestProjectDbContext _context;
        public AddMovieCommandHandler(ITestProjectDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == request.CategoryId);

            if (category == null) throw new Exception("Category not exists");

            var movie = new Movie
            {
                Category_Id = request.CategoryId,
                Name = request.Name,
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };


            await _context.Movies.AddAsync(movie);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
