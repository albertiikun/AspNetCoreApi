using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Application.Interfaces;

namespace IPT.TestProject.Application.Services.Categories.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ITestProjectDbContext _context;
        public DeleteCategoryCommandHandler(ITestProjectDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (category == null) throw new Exception("Category not exists");

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
