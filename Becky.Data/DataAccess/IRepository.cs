using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Becky.Data.DataAccess
{
    public interface IRepository<TEntity> : IQueryable
        where TEntity : class
    {
        int CountAll(params Expression<Func<TEntity, object>>[] includeProperties);
        int Count(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> @where, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity Single(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity First(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
        void Delete(TEntity entity);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void SaveChanges();
    }
}