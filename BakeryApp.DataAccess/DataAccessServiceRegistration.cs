using BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BakeryApp.DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BakeryAppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BakeryAppDb"));
            });
            return services;
        }
    }
}
