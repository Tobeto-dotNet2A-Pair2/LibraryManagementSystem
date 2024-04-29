using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TranslatorMaterialConfiguration : IEntityTypeConfiguration<TranslatorMaterial>
{
    public void Configure(EntityTypeBuilder<TranslatorMaterial> builder)
    {
        builder.ToTable("TranslatorMaterials").HasKey(tm => tm.Id);

        builder.Property(tm => tm.Id).HasColumnName("Id").IsRequired();
        builder.Property(tm => tm.TranslatorId).HasColumnName("TranslatorId");
        builder.Property(tm => tm.MaterialId).HasColumnName("MaterialId");
        builder.Property(tm => tm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(tm => tm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(tm => tm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(tm => !tm.DeletedDate.HasValue);
    }
}