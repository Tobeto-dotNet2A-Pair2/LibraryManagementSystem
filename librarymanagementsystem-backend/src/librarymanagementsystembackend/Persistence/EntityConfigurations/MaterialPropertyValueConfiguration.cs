using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaterialPropertyValueConfiguration : IEntityTypeConfiguration<MaterialPropertyValue>
{
    public void Configure(EntityTypeBuilder<MaterialPropertyValue> builder)
    {
        builder.ToTable("MaterialPropertyValues").HasKey(mpv => mpv.Id);

        builder.Property(mpv => mpv.Id).HasColumnName("Id").IsRequired();
        builder.Property(mpv => mpv.MaterialPropertyValueName).HasColumnName("MaterialPropertyValueName");
        builder.Property(mpv => mpv.MaterialId).HasColumnName("MaterialId");
        builder.Property(mpv => mpv.MaterialTypeId).HasColumnName("MaterialTypeId");
        builder.Property(mpv => mpv.MaterialPropertyId).HasColumnName("MaterialPropertyId");
        builder.Property(mpv => mpv.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mpv => mpv.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mpv => mpv.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(mpv => mpv.MaterialProperty);
        builder.HasOne(mpv => mpv.Material);
        builder.HasOne(mpv => mpv.MaterialType);


        builder.HasQueryFilter(mpv => !mpv.DeletedDate.HasValue);
    }
}