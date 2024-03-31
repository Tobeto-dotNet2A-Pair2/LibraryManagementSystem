using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaterialCopyConfiguration : IEntityTypeConfiguration<MaterialCopy>
{
    public void Configure(EntityTypeBuilder<MaterialCopy> builder)
    {
        builder.ToTable("MaterialCopies").HasKey(mc => mc.Id);

        builder.Property(mc => mc.Id).HasColumnName("Id").IsRequired();
        builder.Property(mc => mc.DateReceipt).HasColumnName("DateReceipt");
        builder.Property(mc => mc.Status).HasColumnName("Status");
        builder.Property(mc => mc.MaterialId).HasColumnName("MaterialId");
        builder.Property(mc => mc.BranchId).HasColumnName("BranchId");
        builder.Property(mc => mc.LocationId).HasColumnName("LocationId");
        builder.Property(mc => mc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mc => mc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mc => mc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(mc => !mc.DeletedDate.HasValue);
    }
}