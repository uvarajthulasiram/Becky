using System;

namespace Becky.Data.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IObjectContext _objectContext;

        public UnitOfWork(IObjectContext objectContext)
        {
            _objectContext = objectContext;
        }

        public void Commit()
        {
            _objectContext.SaveChanges();
        }

        public bool LazyLoadingEnabled
        {
            set { _objectContext.ContextOptions.LazyLoadingEnabled = value; }
            get { return _objectContext.ContextOptions.LazyLoadingEnabled; }
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _objectContext?.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}