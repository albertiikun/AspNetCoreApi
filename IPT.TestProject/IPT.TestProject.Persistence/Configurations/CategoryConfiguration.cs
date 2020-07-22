using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IPT.TestProject.Domain.Entities;

namespace IPT.TestProject.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();

            Relations(builder);

            builder.ToTable("Categories");
        }

        private void Relations(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x => x.Movies)
                .WithOne(x => x.Category)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
