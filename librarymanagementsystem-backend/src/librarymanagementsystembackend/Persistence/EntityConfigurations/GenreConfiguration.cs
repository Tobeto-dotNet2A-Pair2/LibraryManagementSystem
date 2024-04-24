using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("Genres").HasKey(g => g.Id);

        builder.Property(g => g.Id).HasColumnName("Id").IsRequired();
        builder.Property(g => g.Name).HasColumnName("Name");
        builder.Property(g => g.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(g => g.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(g => g.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(g => !g.DeletedDate.HasValue);
    }
}