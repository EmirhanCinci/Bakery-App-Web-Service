using AutoMapper;
using Infrastructure.DataAccess.Interfaces;
using Infrastructure.Model.Implementations;
using Infrastructure.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace Infrastructure.DataAccess.Implementations.EntityFrameworkCore
{
    public class EfBaseRepository<TEntity, TEntityId, TContext> : IBaseRepository<TEntity, TEntityId> where TEntity : Entity<TEntityId> where TContext : DbContext
    {
        protected readonly TContext Context;

        public EfBaseRepository(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                entity.CreatedDate = DateTime.UtcNow;
            }
            await Context.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null, bool enableTracking = true, bool withDeleted = false)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking)
            {
                queryable = queryable.AsNoTracking();
            }
            if (withDeleted)
            {
                queryable = queryable.IgnoreQueryFilters();
            }
            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }
            return await queryable.AnyAsync();
        }

        public async Task<bool> AnyIdAsync(TEntityId id, bool enableTracking = true, bool withDeleted = false)
        {
            return await AnyAsync(prd => prd.Id.Equals(id), enableTracking, withDeleted);
        }

        public async Task DeleteAsync(TEntity entity, bool permanent = false)
        {
            await SetEntityAsDeletedAsync(entity, permanent);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false)
        {
            await SetEntityAsDeletedAsync(entities, permanent);
            await Context.SaveChangesAsync();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, bool enableTracking = true, bool withDeleted = false, params string[] includeList)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking)
            {
                queryable = queryable.AsNoTracking();
            }
            if (includeList != null)
            {
                foreach (var include in includeList)
                {
                    queryable = queryable.Include(include);
                }
            }
            if (withDeleted)
            {
                queryable = queryable.IgnoreQueryFilters();
            }
            return await queryable.SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity?> GetByIdAsync(TEntityId id, bool enableTracking = true, bool withDeleted = false, params string[] includeList)
        {
            return await GetAsync(predicate: prd => prd.Id.Equals(id), enableTracking, withDeleted, includeList);
        }

        public async Task<ICollection<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, int? takeCount = null, bool enableTracking = true, bool withDeleted = false, params string[] includeList)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking)
            {
                queryable = queryable.AsNoTracking();
            }
            if (includeList != null)
            {
                foreach (var include in includeList)
                {
                    queryable = queryable.Include(include);
                }
            }
            if (withDeleted)
            {
                queryable = queryable.IgnoreQueryFilters();
            }
            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }
            if (orderBy != null)
            {
                queryable = orderBy(queryable);
            }
            if (takeCount.HasValue)
            {
                return await queryable.Take(takeCount.Value).ToListAsync();
            }
            return await queryable.ToListAsync();
        }

        public IQueryable<TEntity> Query() => Context.Set<TEntity>();

        public async Task UpdateAsync(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            var trackedEntity = Context.Set<TEntity>().Local.SingleOrDefault(p => p.Id.Equals(entity.Id));
            if (trackedEntity == null)
            {
                Context.Set<TEntity>().Update(entity);
            }
            else if (!ReferenceEquals(trackedEntity, entity))
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TEntity, TEntity>();
                });
                var mapper = configuration.CreateMapper();
                mapper.Map(entity, trackedEntity);
                Context.Entry(trackedEntity).State = EntityState.Modified;
            }
            await Context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(ICollection<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                entity.UpdatedDate = DateTime.UtcNow;
            }
            Context.UpdateRange(entities);
            await Context.SaveChangesAsync();
        }

        protected async Task SetEntityAsDeletedAsync(TEntity entity, bool permanent)
        {
            if (!permanent)
            {
                CheckHasEntityHaveOneToOneRelation(entity);
                await setEntityAsSoftDeletedAsync(entity);
            }
            else
            {
                Context.Remove(entity);
                await Context.SaveChangesAsync();
            }
        }

        protected void CheckHasEntityHaveOneToOneRelation(TEntity entity)
        {
            bool hasEntityHaveOneToOneRelation = Context.Entry(entity).Metadata.GetForeignKeys().All(
                x => x.DependentToPrincipal?.IsCollection == true || x.PrincipalToDependent?.IsCollection == true
                || x.DependentToPrincipal?.ForeignKey.DeclaringEntityType.ClrType == entity.GetType()) == false;
            if (hasEntityHaveOneToOneRelation)
            {
                throw new InvalidOperationException("Entity has one-to-one relationship. Soft Delete causes problems if you try to create entry again by same foreign key.");
            }
        }

        private async Task setEntityAsSoftDeletedAsync(IEntityTimestamps entity)
        {
            if (entity.DeletedDate.HasValue)
            {
                return;
            }
            entity.DeletedDate = DateTime.UtcNow;

            var navigations = Context.Entry(entity).Metadata.GetNavigations()
                .Where(x => x is { IsOnDependent: false, ForeignKey.DeleteBehavior: DeleteBehavior.ClientCascade or DeleteBehavior.Cascade }).ToList();
            foreach (INavigation? navigation in navigations)
            {
                if (navigation.TargetEntityType.IsOwned())
                {
                    continue;
                }
                if (navigation.PropertyInfo == null)
                {
                    continue;
                }

                object? navValue = navigation.PropertyInfo.GetValue(entity);
                if (navigation.IsCollection)
                {
                    if (navValue == null)
                    {
                        IQueryable query = Context.Entry(entity).Collection(navigation.PropertyInfo.Name).Query();
                        navValue = await GetRelationLoaderQuery(query, navigationPropertyType: navigation.PropertyInfo.GetType()).ToListAsync();
                        if (navValue == null)
                        {
                            continue;
                        }
                    }

                    foreach (IEntityTimestamps navValueItem in (IEnumerable)navValue)
                    {
                        await setEntityAsSoftDeletedAsync(navValueItem);
                    }
                }
                else
                {
                    if (navValue == null)
                    {
                        IQueryable query = Context.Entry(entity).Reference(navigation.PropertyInfo.Name).Query();
                        navValue = await GetRelationLoaderQuery(query, navigationPropertyType: navigation.PropertyInfo.GetType())
                            .FirstOrDefaultAsync();
                        if (navValue == null)
                        {
                            continue;
                        }
                    }
                    await setEntityAsSoftDeletedAsync((IEntityTimestamps)navValue);
                }
            }
            Context.Update(entity);
        }

        protected IQueryable<object> GetRelationLoaderQuery(IQueryable query, Type navigationPropertyType)
        {
            Type queryProviderType = query.Provider.GetType();
            MethodInfo createQueryMethod = queryProviderType.GetMethods().First
                (m => m is { Name: nameof(query.Provider.CreateQuery), IsGenericMethod: true })?.MakeGenericMethod(navigationPropertyType)
                ?? throw new InvalidOperationException("CreateQuery<TElement> method is not found in IQueryProvider.");
            var queryProviderQuery = (IQueryable<object>)createQueryMethod.Invoke(query.Provider, parameters: new object[] { query.Expression })!;
            return queryProviderQuery.Where(x => !((IEntityTimestamps)x).DeletedDate.HasValue);
        }

        protected async Task SetEntityAsDeletedAsync(IEnumerable<TEntity> entities, bool permanent)
        {
            foreach (TEntity entity in entities)
            {
                await SetEntityAsDeletedAsync(entity, permanent);
            }
        }
    }
}
