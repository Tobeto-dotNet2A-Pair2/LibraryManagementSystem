using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder.ToTable("PaymentMethods").HasKey(pm => pm.Id);

        builder.Property(pm => pm.Id).HasColumnName("Id").IsRequired();
        builder.Property(pm => pm.BranchId).HasColumnName("BranchId");
        builder.Property(pm => pm.PaymentMethodName).HasColumnName("PaymentMethodName");
        builder.Property(pm => pm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pm => pm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pm => pm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(pm => pm.Branch);
        builder.HasQueryFilter(pm => !pm.DeletedDate.HasValue);
    }
}