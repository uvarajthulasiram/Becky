using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Becky.Data.DataAccess
{
    public class ContextAdapter : IObjectContext, IObjectSetFactory
    {
        private readonly ObjectContext _context;

        public ContextAdapter(IDbContext context)
        {
            _context = context.GetObjectContext();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public ObjectContextOptions ContextOptions => _context.ContextOptions;

        public IObjectSet<T> CreateObjectSet<T>() where T : class
        {
            return _context.CreateObjectSet<T>();
        }

        public void ChangeObjectState(object entity, EntityState state)
        {
            _context.ObjectStateManager.ChangeObjectState(entity, state);
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context?.Dispose();
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