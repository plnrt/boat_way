using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public interface IRepository<T>
    {
        Task Add(T Entity);
        Task Delete(int Id);
        Task Delete(T Entity);
        Task Clear();
        Task Modify(int Id, T NewItem);
        Task<T> Get(int Id);
        Task<T> GetByPosition(int Position);
        List<T> GetAll();
        List<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        List<T> GetAll(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
    }
}
