using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaterialImageConfiguration : IEntityTypeConfiguration<MaterialImage>
{
    public void Configure(EntityTypeBuilder<MaterialImage> builder)
    {
        builder.ToTable("MaterialImages").HasKey(mi => mi.Id);

        builder.Property(mi => mi.Id).HasColumnName("Id").IsRequired();
        builder.Property(mi => mi.Url).HasColumnName("Url");
        builder.Property(mi => mi.MaterialId).HasColumnName("MaterialId");
        builder.Property(mi => mi.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mi => mi.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mi => mi.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(mi => !mi.DeletedDate.HasValue);
    }
}