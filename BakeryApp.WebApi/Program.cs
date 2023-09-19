using Autofac.Extensions.DependencyInjection;
using Autofac;
using BakeryApp.Business.DependecyResolvers.Autofac;
using BakeryApp.Business;
using BakeryApp.DataAccess;
using Infrastructure.DependecyResolvers.Implementations;
using Infrastructure.DependecyResolvers.Interfaces;
using Infrastructure.Extensions;
using BakeryApp.WebApi.Middlewares;
using AspNetCoreRateLimit;

namespace BakeryApp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>
                (containerBuilder => containerBuilder.RegisterModule(new AutofacBusinessModule()));

            builder.Services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });
            builder.Services.AddDataAccessServices(builder.Configuration);
            builder.Services.AddBusinessServices(builder.Configuration);
            builder.Services.AddWebApiServices(builder.Configuration);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/bakeryAppV1/swagger.json", "BakeryApp Api");
                });
            }

            var IpPolicy = app.Services.GetRequiredService<IIpPolicyStore>();
            IpPolicy.SeedAsync().Wait();

            app.UseIpRateLimiting();

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.UseCustomException();

            app.Run();
        }
    }
}
