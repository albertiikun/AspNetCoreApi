using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Application.Interfaces;

namespace IPT.TestProject.Application.Services.Movies.Commands.Delete
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Unit>
    {
        private readonly ITestProjectDbContext _context;
        public DeleteMovieCommandHandler(ITestProjectDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie =  await _context.Movies.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (movie == null) throw new Exception("Movie do not exists");

             _context.Movies.Remove(movie);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
