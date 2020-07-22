using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Domain.Entities;

namespace IPT.TestProject.Application.Interfaces
{
    public interface ITestProjectDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<RoleHasPermission> RoleHasPermission { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Movie> Movies { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
