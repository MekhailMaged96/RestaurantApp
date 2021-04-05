
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {

        public IQueryable<TEntity> GetAll();

        public void Insert(TEntity entity);

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null);

        public Task<IEnumerable<TEntity>> GetAllAsync(
                   Expression<Func<TEntity, bool>> filter = null,
                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                   string includeProperties = "",
                   int? take = null);

        public  Task<TEntity> FindAsync(
                    Expression<Func<TEntity, bool>> filter = null,
                    string includeProperties = "");

        void Delete(object id);

        void Delete(TEntity entityToDelete);

    }
}
