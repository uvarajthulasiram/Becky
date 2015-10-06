using System;

namespace Becky.Data.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        bool LazyLoadingEnabled { set; get; }
    }
}