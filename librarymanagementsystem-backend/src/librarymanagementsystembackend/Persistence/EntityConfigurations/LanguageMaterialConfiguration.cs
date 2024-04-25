using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LanguageMaterialConfiguration : IEntityTypeConfiguration<LanguageMaterial>
{
    public void Configure(EntityTypeBuilder<LanguageMaterial> builder)
    {
        builder.ToTable("LanguageMaterials").HasKey(lm => lm.Id);

        builder.Property(lm => lm.Id).HasColumnName("Id").IsRequired();
        builder.Property(lm => lm.LanguageId).HasColumnName("LanguageId");
        builder.Property(lm => lm.MaterialId).HasColumnName("MaterialId");
        builder.Property(lm => lm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lm => lm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lm => lm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(lm => !lm.DeletedDate.HasValue);
    }
}