using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FavoriteListConfiguration : IEntityTypeConfiguration<FavoriteList>
{
    public void Configure(EntityTypeBuilder<FavoriteList> builder)
    {
        builder.ToTable("FavoriteLists").HasKey(fl => fl.Id);

        builder.Property(fl => fl.Id).HasColumnName("Id").IsRequired();
        builder.Property(fl => fl.ListName).HasColumnName("ListName");
        builder.Property(fl => fl.MemberId).HasColumnName("MemberId");
        builder.Property(fl => fl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(fl => fl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(fl => fl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(fl => fl.Member);
        builder.HasMany(fl => fl.FavoriteListMaterials);

        builder.HasQueryFilter(fl => !fl.DeletedDate.HasValue);
    }
}