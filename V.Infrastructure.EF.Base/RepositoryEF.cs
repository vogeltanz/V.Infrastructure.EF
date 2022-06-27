using Microsoft.EntityFrameworkCore;
using V.Domain.Base.Entities.Abstraction;

namespace V.Infrastructure.EF.Base
{
    public class RepositoryEF<T, TKey> : Repository<T, TKey> where T : class, IEntity<TKey>
    {
        protected DbContext dbContext;

        public RepositoryEF(DbContext dbContext) : base(dbContext.Set<T>())
        {
            this.dbContext = dbContext;
        }
    }
}
