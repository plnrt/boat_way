using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.DataBaseManager
{
    public interface IDataBaseManager<T>
    {
        Task Add(T Entity);
        Task Delete(string Id);
        Task Delete(T Entity);
        Task Clear();
        Task Modify(string Id, T NewItem);
        Task<T> Get(string Id);
        Task<T> GetByPosition(int Position);
        List<T> GetAll();
        List<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        List<T> GetAll(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
        void Dispose();
    }
}
