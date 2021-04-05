using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;
        internal DbSet<TEntity> dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            this.dbSet = context.Set<TEntity>();
        
        }
        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = dbSet;
            return query;
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(
                     Expression<Func<TEntity, bool>> filter = null,
                     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                     string includeProperties = "",
                     int? take = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                if (take == null)
                    return await orderBy(query).ToListAsync();
                else
                    return await orderBy(query).Take(take.Value).ToListAsync();
            }
            else
            {
                if (take == null)
                    return await query.ToListAsync();
                else
                    return await query.Take(take.Value).ToListAsync();
            }
        }
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {

            IQueryable<TEntity> query = dbSet;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
              (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync();
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await dbSet.AnyAsync(filter);
        }


        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

     
    }
}
