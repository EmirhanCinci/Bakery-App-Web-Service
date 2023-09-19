using BakeryApp.Model.Entities;
using Infrastructure.Model.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts
{
    public class BakeryAppDbContext : DbContext
    {
        public BakeryAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodComment> FoodComments { get; set; }
        public DbSet<FoodMaterial> FoodMaterials { get; set; }
        public DbSet<FoodPhoto> FoodPhotos { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBasket> UserBaskets { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
    }
}
