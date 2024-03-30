using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BorrowMaterialConfiguration : IEntityTypeConfiguration<BorrowMaterial>
{
    public void Configure(EntityTypeBuilder<BorrowMaterial> builder)
    {
        builder.ToTable("BorrowMaterials").HasKey(bm => bm.Id);

        builder.Property(bm => bm.Id).HasColumnName("Id").IsRequired();
        builder.Property(bm => bm.BorrowDate).HasColumnName("BorrowDate");
        builder.Property(bm => bm.ReturnDate).HasColumnName("ReturnDate");
        builder.Property(bm => bm.MemberId).HasColumnName("MemberId");
        builder.Property(bm => bm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bm => bm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bm => bm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(bm => !bm.DeletedDate.HasValue);
    }
}