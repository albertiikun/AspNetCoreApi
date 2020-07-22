using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using IPT.TestProject.Domain.Entities;

namespace IPT.TestProject.Persistence.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();

            Relations(builder);

            builder.ToTable("Movies");
        }

        private void Relations(EntityTypeBuilder<Movie> builder)
        {
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.Category_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
