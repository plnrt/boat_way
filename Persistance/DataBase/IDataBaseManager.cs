using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.DataBaseManager
{
    public interface IDataBaseManager<T> : IDisposable
    {
        Task Add(DbContext context, T Entity);
        Task Delete(DbContext context, string Id);
        Task Delete(DbContext context, T Entity);
        Task Clear(DbContext context);
        Task Modify(DbContext context, string Id, T NewItem);
        Task<T> Get(DbContext context, string Id);
        Task<T> GetByPosition(DbContext context, int Position);
        List<T> GetAll(DbContext context);
        List<T> GetAll(DbContext context, params Expression<Func<T, object>>[] includeProperties);
        List<T> GetAll(DbContext context, Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
        new void Dispose();
    }
}
