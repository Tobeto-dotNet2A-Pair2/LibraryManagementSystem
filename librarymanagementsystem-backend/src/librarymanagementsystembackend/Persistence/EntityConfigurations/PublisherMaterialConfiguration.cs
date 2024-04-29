using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PublisherMaterialConfiguration : IEntityTypeConfiguration<PublisherMaterial>
{
    public void Configure(EntityTypeBuilder<PublisherMaterial> builder)
    {
        builder.ToTable("PublisherMaterials").HasKey(pm => pm.Id);

        builder.Property(pm => pm.Id).HasColumnName("Id").IsRequired();
        builder.Property(pm => pm.PublisherId).HasColumnName("PublisherId");
        builder.Property(pm => pm.MaterialId).HasColumnName("MaterialId");
        builder.Property(pm => pm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pm => pm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pm => pm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pm => !pm.DeletedDate.HasValue);
    }
}