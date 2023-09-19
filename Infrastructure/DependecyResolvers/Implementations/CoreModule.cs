using Infrastructure.CrossCuttingConcerns.Caching.Implementations.Microsoft;
using Infrastructure.CrossCuttingConcerns.Caching.Interfaces;
using Infrastructure.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Infrastructure.DependecyResolvers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Infrastructure.DependecyResolvers.Implementations
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
            services.AddTransient<FileLogger>();
        }
    }
}
