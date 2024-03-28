using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Persistence.EntityConfigurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("Members").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.FirstName).HasColumnName("FirstName");
        builder.Property(m => m.LastName).HasColumnName("LastName");
        builder.Property(m => m.TC).HasColumnName("TC");
        builder.Property(m => m.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(m => m.Photograph).HasColumnName("Photograph");
        builder.Property(m => m.MemberShipDate).HasColumnName("MemberShipDate");
        builder.Property(m => m.Reservation).HasColumnName("Reservation");
        builder.Property(m => m.Messages).HasColumnName("Messages");
        builder.Property(m => m.AskLibrarianTopic).HasColumnName("AskLibrarianTopic");
        builder.Property(m => m.AskLibrarianDescription).HasColumnName("AskLibrarianDescription");
        builder.Property(m => m.UserId).HasColumnName("UserId");
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(m => m.User);
     

           
      

        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}