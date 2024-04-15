using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AuthorMaterialConfiguration : IEntityTypeConfiguration<AuthorMaterial>
{
    public void Configure(EntityTypeBuilder<AuthorMaterial> builder)
    {
        builder.ToTable("AuthorMaterials").HasKey(am => am.Id);

        builder.Property(am => am.Id).HasColumnName("Id").IsRequired();
        builder.Property(am => am.AuthorId).HasColumnName("AuthorId");
        builder.Property(am => am.MaterialId).HasColumnName("MaterialId");
        builder.Property(am => am.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(am => am.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(am => am.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(am => am.Author);
        builder.HasOne(am => am.Material);

        builder.HasQueryFilter(am => !am.DeletedDate.HasValue);
    }
}