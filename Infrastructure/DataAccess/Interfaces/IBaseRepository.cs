using Infrastructure.Model.Implementations;

namespace Infrastructure.DataAccess.Interfaces
{
    public interface IBaseRepository<TEntity, TEntityId> : IQuery<TEntity>, IAsyncRepository<TEntity, TEntityId> where TEntity : Entity<TEntityId>
    {
    }
}
