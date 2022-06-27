using Microsoft.EntityFrameworkCore;
using V.Domain.Base.Entities.Abstraction;

namespace V.Infrastructure.EF.Base
{
    public class RepositoryEF<T, TKey> : Repository<T, TKey>, IDisposable where T : class, IEntity<TKey>
    {
        protected DbContext dbContext;

        public RepositoryEF(DbContext dbContext) : base(dbContext.Set<T>())
        {
            this.dbContext = dbContext;
        }




        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                {
                    dbContext?.Dispose();
                }
            _disposed = true;
        }
    }
}
