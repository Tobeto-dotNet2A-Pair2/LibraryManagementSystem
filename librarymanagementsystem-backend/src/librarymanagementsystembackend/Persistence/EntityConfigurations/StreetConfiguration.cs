using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StreetConfiguration : IEntityTypeConfiguration<Street>
{
    public void Configure(EntityTypeBuilder<Street> builder)
    {
        builder.ToTable("Streets").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.StreetName).HasColumnName("StreetName");
        builder.Property(s => s.NeighborhoodId).HasColumnName("NeighborhoodId");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");
        builder.HasMany(s => s.Addresses);
        builder.HasOne(s => s.Neighborhood);
        

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}