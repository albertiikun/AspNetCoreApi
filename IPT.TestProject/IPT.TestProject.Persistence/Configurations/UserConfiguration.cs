using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IPT.TestProject.Domain.Entities;

namespace IPT.TestProject.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
       
        public void Configure(EntityTypeBuilder<User> builder)
        {

            RelationShips(builder);
        }


        private void RelationShips(EntityTypeBuilder<User> builder)
        {
          
            builder.HasMany(e => e.UserRoles)
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        }
    }
}
