using Infrastructure.Model.Implementations;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.Interfaces
{
    public interface IAsyncRepository<TEntity, TEntityId> where TEntity : Entity<TEntityId>
    {
        Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            bool enableTracking = true,
            bool withDeleted = false,
            params string[] includeList
        );

        Task<TEntity?> GetByIdAsync(
            TEntityId id,
            bool enableTracking = true,
            bool withDeleted = false,
            params string[] includeList
        );

        Task<ICollection<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            int? takeCount = null,
            bool enableTracking = true,
            bool withDeleted = false,
            params string[] includeList
        );

        Task<bool> AnyAsync(
           Expression<Func<TEntity, bool>>? predicate = null,
           bool enableTracking = true,
           bool withDeleted = false
        );

        Task<bool> AnyIdAsync(
           TEntityId id,
           bool enableTracking = true,
           bool withDeleted = false
        );

        Task<TEntity> AddAsync(TEntity entity);

        Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities);

        Task UpdateAsync(TEntity entity);

        Task UpdateRangeAsync(ICollection<TEntity> entities);

        Task DeleteAsync(TEntity entity, bool permanent = false);

        Task DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false);
    }
}
