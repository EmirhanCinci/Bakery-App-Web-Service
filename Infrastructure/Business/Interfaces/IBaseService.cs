using Infrastructure.Model.Implementations;

namespace Infrastructure.Business.Interfaces
{
    public interface IBaseService<TEntity, TEntityId> where TEntity : Entity<TEntityId>
    {
        Task<bool> AnyAsync(TEntityId id);
    }
}
