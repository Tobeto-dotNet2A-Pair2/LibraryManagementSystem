using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaterialPropertyConfiguration : IEntityTypeConfiguration<MaterialProperty>
{
    public void Configure(EntityTypeBuilder<MaterialProperty> builder)
    {
        builder.ToTable("MaterialProperties").HasKey(mp => mp.Id);

        builder.Property(mp => mp.Id).HasColumnName("Id").IsRequired();
        builder.Property(mp => mp.MaterialPropertyName).HasColumnName("MaterialPropertyName");
        builder.Property(mp => mp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mp => mp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mp => mp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(mp => mp.MaterialPropertyValues);

        builder.HasQueryFilter(mp => !mp.DeletedDate.HasValue);
    }
}