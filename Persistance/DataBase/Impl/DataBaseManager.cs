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
        private DbContext Context;
        private DbSet<T> DbSet;
        public DataBaseManager(DbContext context)
        {
            this.Context = context;
            DbSet = context.Set<T>();
        }
        public async Task Add(T Entity)
        {
            DbSet.Add(Entity);
            await Context.SaveChangesAsync();
        }
        public async Task Delete(string Id)
        {
            DbSet.Remove(DbSet.Find(Id));
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task Delete(T Entity)
        {
            Context.Entry(Entity).State = EntityState.Deleted;
            Context.SaveChangesAsync();
        }
        public async Task Clear()
        {
            DbSet.RemoveRange(DbSet);
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task Modify(string Id, T NewItem)
        {
            Context.Entry(Context.Set<T>().Find(Id)).CurrentValues.SetValues(NewItem);
            Context.SaveChangesAsync();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.SuppressFinalize(this);
        }

        public async Task<T> Get(string Id)
        {
            return await DbSet.FindAsync(Id).ConfigureAwait(false);
        }
        public async Task<T> GetByPosition(int Position)
        {
            var result = await DbSet.ToListAsync().ConfigureAwait(false);
            return result[Position];
        }
        public List<T> GetAll()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public List<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = DbSet.AsQueryable();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }

        public List<T> GetAll(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = DbSet.Where(predicate).AsQueryable();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }
    }
}
