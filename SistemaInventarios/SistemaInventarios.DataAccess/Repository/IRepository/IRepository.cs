using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarios.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);

        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            bool isTraking = true
            );

        Task<T> GetFirst(Expression<Func<T, bool>> filter,            
            string includeProperties = null,
            bool isTraking = true);

        Task Insert(T item);

        void Delete(T item);

        void DeleteRange(IEnumerable<T> items);


    }
}
