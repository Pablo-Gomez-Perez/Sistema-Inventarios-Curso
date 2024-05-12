using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaInventarios.DataAccess.Data;
using SistemaInventarios.DataAccess.Repository.IRepository;

namespace SistemaInventarios.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = context.Set<T>();
        }

        public void Delete(T item)
        {
            dbSet.Remove(item);
        }

        public void DeleteRange(IEnumerable<T> items)
        {
            dbSet.RemoveRange(items);
        }

        public async Task<T> Get(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            string includeProperties = null,
            bool isTraking = true)
        {
            IQueryable<T> query = dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }

            if(includeProperties != null)
            {
                foreach(var property in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            if(orderBy != null)
            {
                query = orderBy(query);
            }

            if (isTraking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetFirst(Expression<Func<T, bool>> filter, string includeProperties = null, bool isTraking = true)
        {
            IQueryable<T> query = dbSet;

            if(filter != null)
                query = query.Where(filter);

            if(includeProperties != null)
                foreach(var property in includeProperties.Split(new char[] {','} , StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(property);

            if(isTraking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task Insert(T item)
        {
            await dbSet.AddAsync(item);
        }
    }
}
