using System;
using System.Data.Entity.Core.Objects;

namespace Becky.Data.DataAccess
{
    public interface IObjectContext : IDisposable
    {
        void SaveChanges();
        ObjectContextOptions ContextOptions { get; }
    }
}