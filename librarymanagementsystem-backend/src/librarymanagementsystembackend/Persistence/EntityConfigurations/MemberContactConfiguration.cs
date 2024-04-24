using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MemberContactConfiguration : IEntityTypeConfiguration<MemberContact>
{
    public void Configure(EntityTypeBuilder<MemberContact> builder)
    {
        builder.ToTable("MemberContacts").HasKey(mc => mc.Id);

        builder.Property(mc => mc.Id).HasColumnName("Id").IsRequired();
        builder.Property(mc => mc.AskLibrarianTopic).HasColumnName("AskLibrarianTopic");
        builder.Property(mc => mc.AskLibrarianDescription).HasColumnName("AskLibrarianDescription");
        builder.Property(mc => mc.Message).HasColumnName("Message");
        builder.Property(mc => mc.MemberId).HasColumnName("MemberId");
        builder.Property(mc => mc.LibraryId).HasColumnName("LibraryId");
        builder.Property(mc => mc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mc => mc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mc => mc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(mc => !mc.DeletedDate.HasValue);
    }
}