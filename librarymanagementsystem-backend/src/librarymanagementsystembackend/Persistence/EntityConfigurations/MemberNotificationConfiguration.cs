using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MemberNotificationConfiguration : IEntityTypeConfiguration<MemberNotification>
{
    public void Configure(EntityTypeBuilder<MemberNotification> builder)
    {
        builder.ToTable("MemberNotifications").HasKey(mn => mn.Id);

        builder.Property(mn => mn.Id).HasColumnName("Id").IsRequired();
        builder.Property(mn => mn.MemberId).HasColumnName("MemberId");
        builder.Property(mn => mn.NotificationId).HasColumnName("NotificationId");
        builder.Property(mn => mn.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mn => mn.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mn => mn.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(mn => !mn.DeletedDate.HasValue);
    }
}