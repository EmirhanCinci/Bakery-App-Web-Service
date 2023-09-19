using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependecyResolvers.Interfaces
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
