using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class NeighborhoodConfiguration : IEntityTypeConfiguration<Neighborhood>
{
    public void Configure(EntityTypeBuilder<Neighborhood> builder)
    {
        builder.ToTable("Neighborhoods").HasKey(n => n.Id);

        builder.Property(n => n.Id).HasColumnName("Id").IsRequired();
        builder.Property(n => n.NeighborhoodName).HasColumnName("NeighborhoodName");
        builder.Property(n => n.DistrictId).HasColumnName("DistrictId");
        builder.Property(n => n.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(n => n.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(n => n.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(n => !n.DeletedDate.HasValue);
    }
}