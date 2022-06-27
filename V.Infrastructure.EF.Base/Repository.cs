using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using V.Domain.Base.Entities.Abstraction;
using V.Domain.Base.Repository;

namespace V.Infrastructure.EF.Base
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class, IEntity<TKey>
    {
        internal DbSet<T> dbSet;

        public Repository(DbSet<T> dbSet)
        {
            this.dbSet = dbSet;
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            dbSet.Update(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public virtual T GetById(TKey id)
        {
            return dbSet.FirstOrDefault(entity => entity.Id.Equals(id));
        }
    }
}
