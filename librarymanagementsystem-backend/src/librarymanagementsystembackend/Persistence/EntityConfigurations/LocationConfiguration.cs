using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations").HasKey(l => l.Id);

        builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
        builder.Property(l => l.ShelfLineNumber).HasColumnName("ShelfLineNumber");
        builder.Property(l => l.ShelfFloor).HasColumnName("ShelfFloor");
        builder.Property(l => l.Shelf).HasColumnName("Shelf");
        builder.Property(l => l.Corridor).HasColumnName("Corridor");
        builder.Property(l => l.Floor).HasColumnName("Floor");
        builder.Property(l => l.FullLocationMap).HasColumnName("FullLocationMap");
        builder.Property(l => l.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(l => l.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(l => l.DeletedDate).HasColumnName("DeletedDate");


        builder.HasOne(l => l.MaterialCopy);
        builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
    }
}