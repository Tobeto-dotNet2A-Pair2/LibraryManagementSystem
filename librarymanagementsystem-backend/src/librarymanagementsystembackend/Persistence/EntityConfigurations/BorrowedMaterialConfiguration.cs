using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BorrowedMaterialConfiguration : IEntityTypeConfiguration<BorrowedMaterial>
{
    public void Configure(EntityTypeBuilder<BorrowedMaterial> builder)
    {
        builder.ToTable("BorrowedMaterials").HasKey(bm => bm.Id);

        builder.Property(bm => bm.Id).HasColumnName("Id").IsRequired();
        builder.Property(bm => bm.BorrowedDate).HasColumnName("BorrowedDate");
        builder.Property(bm => bm.ReturnDate).HasColumnName("ReturnDate");
        builder.Property(bm => bm.IsReturned).HasColumnName("IsReturned");
        builder.Property(bm => bm.MemberId).HasColumnName("MemberId");
        builder.Property(bm => bm.MaterialCopyId).HasColumnName("MaterialCopyId");
        builder.Property(bm => bm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bm => bm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bm => bm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(bm => !bm.DeletedDate.HasValue);
    }
}