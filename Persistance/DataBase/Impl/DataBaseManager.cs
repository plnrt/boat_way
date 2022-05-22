using Persistance.DataBaseManager;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistance.DataBase.Impl
{
    public class DataBaseManager<T> : IDataBaseManager<T> where T : class
    {
        public async Task Add(DbContext context, T Entity)
        {
            var Context = context;
            var DbSet = context.Set<T>();
            DbSet.Add(Entity);
            await Context.SaveChangesAsync();
        }
        public async Task Delete(DbContext context, string Id)
        {
            var Context = context;
            var DbSet = context.Set<T>();
            DbSet.Remove(DbSet.Find(Id));
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task Delete(DbContext context, T Entity)
        {
            var Context = context;
            Context.Entry(Entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task Clear(DbContext context)
        {
            var Context = context;
            var DbSet = context.Set<T>();
            DbSet.RemoveRange(DbSet);
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task Modify(DbContext context, string Id, T NewItem)
        {
            var Context = context;
            Context.Entry(Context.Set<T>().Find(Id)).CurrentValues.SetValues(NewItem);
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.SuppressFinalize(this);
        }

        public async Task<T> Get(DbContext context, string Id)
        {
            var DbSet = context.Set<T>();
            return await DbSet.FindAsync(Id).ConfigureAwait(false);
        }
        public async Task<T> GetByPosition(DbContext context, int Position)
        {
            var DbSet = context.Set<T>();
            var result = await DbSet.ToListAsync().ConfigureAwait(false);
            return result[Position];
        }
        public List<T> GetAll(DbContext context)
        {
            var DbSet = context.Set<T>();
            return DbSet.AsNoTracking().ToList();
        }

        public List<T> GetAll(DbContext context, params Expression<Func<T, object>>[] includeProperties)
        {
            var Context = context;
            var DbSet = context.Set<T>();
            var query = DbSet.AsQueryable();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }

        public List<T> GetAll(DbContext context, Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var Context = context;
            var DbSet = context.Set<T>();
            var query = DbSet.Where(predicate).AsQueryable();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }
    }
}
