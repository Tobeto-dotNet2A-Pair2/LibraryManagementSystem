using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PenaltyConfiguration : IEntityTypeConfiguration<Penalty>
{
    public void Configure(EntityTypeBuilder<Penalty> builder)
    {
        builder.ToTable("Penalties").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.TotalMaterialPenalty).HasColumnName("TotalMaterialPenalty");
        builder.Property(p => p.DayDelay).HasColumnName("DayDelay");
        builder.Property(p => p.NotificationId).HasColumnName("NotificationId");
        builder.Property(p => p.BorrowedMaterialId).HasColumnName("BorrowedMaterialId");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");


        builder.HasOne(p => p.BorrowedMaterial);
        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }
}