using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Application.Interfaces;

namespace IPT.TestProject.Application.Services.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ITestProjectDbContext _context;
        public UpdateCategoryCommandHandler(ITestProjectDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (category == null) throw new Exception("category not exists");

            category.Name = request.Name;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
