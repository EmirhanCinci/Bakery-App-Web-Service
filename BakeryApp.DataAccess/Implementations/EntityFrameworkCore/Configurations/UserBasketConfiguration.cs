using BakeryApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Configurations
{
    public class UserBasketConfiguration : IEntityTypeConfiguration<UserBasket>
    {
        public void Configure(EntityTypeBuilder<UserBasket> builder)
        {
            builder.ToTable("UserBaskets").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(x => x.FoodId).HasColumnName("FoodId").IsRequired();
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

            builder.HasOne(x => x.Food);
            builder.HasOne(x => x.User);

            builder.HasQueryFilter(x => !x.DeletedDate.HasValue);
        }
    }
}
