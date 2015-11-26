using Queries.Core.Repositories;

namespace Queries.Persistence
{
    public static class ObjectFactory
    {
        internal static TRepository GetInstance<T, TRepository>() where TRepository : IRepository<T>, new() where T : class
        {
            return new TRepository();
        }
    }
}