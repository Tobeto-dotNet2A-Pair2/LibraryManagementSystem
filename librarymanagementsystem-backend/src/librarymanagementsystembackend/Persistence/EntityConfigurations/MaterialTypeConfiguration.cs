using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaterialTypeConfiguration : IEntityTypeConfiguration<MaterialType>
{
    public void Configure(EntityTypeBuilder<MaterialType> builder)
    {
        builder.ToTable("MaterialTypes").HasKey(mt => mt.Id);

        builder.Property(mt => mt.Id).HasColumnName("Id").IsRequired();
        builder.Property(mt => mt.Name).HasColumnName("Name");
        builder.Property(mt => mt.MaterialFormat).HasColumnName("MaterialFormat");
        builder.Property(mt => mt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mt => mt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mt => mt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(mt => !mt.DeletedDate.HasValue);
    }
}