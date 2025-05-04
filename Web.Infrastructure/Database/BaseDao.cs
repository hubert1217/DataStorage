using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities.Base;
using Web.Infrastructure.Database.Context;

namespace Web.Infrastructure.Database
{
    public abstract class BaseDao<TEntity>(DataStorageAppContext dbContext) where TEntity : class, IBaseEntity
    {
        protected readonly DataStorageAppContext Context = dbContext;

        protected virtual IQueryable<TEntity> GetQueryable()
        {
            return Context.Set<TEntity>().AsNoTracking();
        }

        public virtual async Task<List<TEntity>> GetAll() 
        {
            return await GetQueryable().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            var entity = await Context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new KeyNotFoundException($"{typeof(TEntity).Name} with id {id} not found.");
            }

            return entity;
        }

        public virtual async Task<TEntity> Update(int id, TEntity update) 
        {
            if (id != update.Id)
                throw new ArgumentException("ID mismatch between route and entity");

            var entity = await GetById(id);
            Context.Entry(entity).CurrentValues.SetValues(update);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Insert(TEntity entity) 
        { 
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var delete = await GetById(id);
            Context.Set<TEntity>().Remove(delete);
            await Context.SaveChangesAsync();
        }
    }
}
