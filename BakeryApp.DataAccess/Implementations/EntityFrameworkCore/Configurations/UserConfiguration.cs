using BakeryApp.Model.Entities;
using Infrastructure.Model.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(x => x.Id);

            builder.Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(100);
            builder.Property(x => x.CityId).HasColumnName("CityId").IsRequired();
            builder.Property(x => x.GenderId).HasColumnName("GenderId").IsRequired();
            builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash").IsRequired();
            builder.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

            builder.HasOne(x => x.City);
            builder.HasOne(x => x.Gender);

            builder.HasMany(x => x.UserBaskets);
            builder.HasMany(x => x.UserFavorites);
            builder.HasMany(x => x.FoodComments);
            builder.HasMany(x => x.Orders);

            builder.HasQueryFilter(x => !x.DeletedDate.HasValue);
        }
    }
}
