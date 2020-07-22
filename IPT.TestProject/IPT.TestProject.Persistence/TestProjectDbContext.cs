using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using IPT.TestProject.Application.Interfaces;
using IPT.TestProject.Domain.Entities;

namespace IPT.TestProject.Persistence
{
    public class TestProjectDbContext : IdentityDbContext<User,Role,Guid,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>, ITestProjectDbContext
    {

        public TestProjectDbContext(DbContextOptions<TestProjectDbContext> options) : base(options) { }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RoleHasPermission> RoleHasPermission { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var table = entityType.GetTableName();
                if (table.StartsWith("AspNet"))
                    entityType.SetTableName(table.Substring(6));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestProjectDbContext).Assembly);
        }

    }
}
