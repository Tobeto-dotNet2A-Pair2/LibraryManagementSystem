using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FavoriteListMaterialConfiguration : IEntityTypeConfiguration<FavoriteListMaterial>
{
    public void Configure(EntityTypeBuilder<FavoriteListMaterial> builder)
    {
        builder.ToTable("FavoriteListMaterials").HasKey(flm => flm.Id);

        builder.Property(flm => flm.Id).HasColumnName("Id").IsRequired();
        builder.Property(flm => flm.FavoriteListId).HasColumnName("FavoriteListId");
        builder.Property(flm => flm.MaterialId).HasColumnName("MaterialId");
        builder.Property(flm => flm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(flm => flm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(flm => flm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(flm => !flm.DeletedDate.HasValue);
    }
}