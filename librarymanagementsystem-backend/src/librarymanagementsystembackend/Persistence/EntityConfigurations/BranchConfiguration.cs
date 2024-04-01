using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("Branches").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.BranchName).HasColumnName("BranchName");
        builder.Property(b => b.WorkingHours).HasColumnName("WorkingHours");
        builder.Property(b => b.Telephone).HasColumnName("Telephone");
        builder.Property(b => b.WebSiteUrl).HasColumnName("WebSiteUrl");
        builder.Property(b => b.AddressId).HasColumnName("AddressId");
        builder.Property(b => b.LibraryId).HasColumnName("LibraryId");
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}