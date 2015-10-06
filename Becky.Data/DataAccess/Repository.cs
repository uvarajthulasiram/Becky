using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace Becky.Data.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class 
    {
        private readonly IObjectSet<TEntity> _objectSet;
        private readonly IObjectSetFactory _objectSetFactory;
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IObjectSetFactory objectSetFactory, IUnitOfWork unitOfWork)
        {
            _objectSet = objectSetFactory.CreateObjectSet<TEntity>();
            _objectSetFactory = objectSetFactory;
            _unitOfWork = unitOfWork;
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _objectSet;
        }

        public virtual int CountAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Count();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Count(where);
        }

        public virtual IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.ToList();
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> @where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        public virtual TEntity Single(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Single(where);
        }

        public virtual TEntity First(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.First(where);
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.SingleOrDefault(where);
        }

        public virtual void Delete(TEntity entity)
        {
            _objectSet.DeleteObject(entity);
        }

        public virtual void Insert(TEntity entity)
        {
            _objectSet.AddObject(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _objectSet.Attach(entity);
            _objectSetFactory.ChangeObjectState(entity, EntityState.Modified);
        }

        private static IQueryable<TEntity> PerformInclusions(IEnumerable<Expression<Func<TEntity, object>>> includeProperties,
                                                       IQueryable<TEntity> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }


        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.FirstOrDefault(where);
        }

        public IEnumerator GetEnumerator()
        {
            return _objectSet.GetEnumerator();
        }

        public Expression Expression => _objectSet.Expression;

        public Type ElementType => _objectSet.ElementType;

        public IQueryProvider Provider => _objectSet.Provider;
    }
}