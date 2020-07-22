using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Application.Interfaces;

namespace IPT.TestProject.Application.Services.Movies.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateMovieCommand, Unit>
    {
        private readonly ITestProjectDbContext _context;
        public UpdateCommandHandler(ITestProjectDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (movie == null) throw new Exception("Movie not exists");

            movie.Name = request.Name;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
