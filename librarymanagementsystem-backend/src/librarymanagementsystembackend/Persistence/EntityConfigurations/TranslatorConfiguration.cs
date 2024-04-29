using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TranslatorConfiguration : IEntityTypeConfiguration<Translator>
{
    public void Configure(EntityTypeBuilder<Translator> builder)
    {
        builder.ToTable("Translators").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.Name).HasColumnName("Name");
        builder.Property(t => t.Description).HasColumnName("Description");
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
    }
}