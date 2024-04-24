using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaterialGenreConfiguration : IEntityTypeConfiguration<MaterialGenre>
{
    public void Configure(EntityTypeBuilder<MaterialGenre> builder)
    {
        builder.ToTable("MaterialGenres").HasKey(mg => mg.Id);

        builder.Property(mg => mg.Id).HasColumnName("Id").IsRequired();
        builder.Property(mg => mg.GenreId).HasColumnName("GenreId");
        builder.Property(mg => mg.MaterialId).HasColumnName("MaterialId");
        builder.Property(mg => mg.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mg => mg.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mg => mg.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(mg => !mg.DeletedDate.HasValue);
    }
}