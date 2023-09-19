using Autofac;
using Autofac.Extras.DynamicProxy;
using BakeryApp.Business.Profiles;
using BakeryApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using Castle.DynamicProxy;
using Infrastructure.Utilities.Interceptors;
using System.Reflection;
using Module = Autofac.Module;

namespace BakeryApp.Business.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var apiAssembly = Assembly.GetExecutingAssembly();
            var repositroyAssembly = Assembly.GetAssembly(typeof(BakeryAppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(CategoryProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repositroyAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repositroyAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
