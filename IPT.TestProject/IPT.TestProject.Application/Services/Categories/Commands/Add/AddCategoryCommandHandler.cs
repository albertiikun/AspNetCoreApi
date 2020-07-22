using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Application.Interfaces;
using IPT.TestProject.Domain.Entities;

namespace IPT.TestProject.Application.Services.Categories.Commands.Add
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Unit>
    {
        private readonly ITestProjectDbContext _context;
        public AddCategoryCommandHandler(ITestProjectDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow

            };
            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
