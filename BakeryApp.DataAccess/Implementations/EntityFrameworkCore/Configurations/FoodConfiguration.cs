using BakeryApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Configurations
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.ToTable("Foods").HasKey(b => b.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            builder.Property(x => x.UnitPrice).HasColumnName("UnitPrice").IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").IsRequired().HasMaxLength(500);
            builder.Property(x => x.CategoryId).HasColumnName("CategoryId").IsRequired();
            builder.Property(x => x.IsStock).HasColumnName("IsStock").IsRequired();
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

            builder.HasOne(x => x.Category);

            builder.HasMany(x => x.FoodMaterials);
            builder.HasMany(x => x.FoodPhotos);
            builder.HasMany(x => x.FoodComments);
            builder.HasMany(x => x.UserBaskets);
            builder.HasMany(x => x.UserFavorites);
            builder.HasMany(x => x.OrderDetails);

            builder.HasQueryFilter(x => !x.DeletedDate.HasValue);
        }
    }
}
