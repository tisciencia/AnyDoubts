using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Linq.Expressions;
using System.Threading;
using System.Web;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using AnyDoubts.Domain.Repository;

namespace AnyDoubts.DAO
{
    public abstract class GenericDAO<T> : IGenericRepository<T>
    {
        private IObjectContainer _Db4oManager;

        public GenericDAO()
        {
            _Db4oManager = ContainerFactory.GetInstance();
        }       

        protected IQueryable<T> GetQuery()
        {
            var query = from T c in _Db4oManager
                        select c;
            return query.AsQueryable();
        }

        public bool IsStored(T entity)
        {
            return _Db4oManager.Ext().IsStored(entity);
        }

        public T Load(Expression<Func<T, bool>> whereCondition)
        {
            return GetQuery().SingleOrDefault(whereCondition);  //return GetQuery().Where(whereCondition).SingleOrDefault();
        }

        public void Add(T entity)
        {
            _Db4oManager.Store(entity);           
        }

        public void Update(T entity)
        {
            _Db4oManager.Store(entity);            
        }

        public void Delete(T entity)
        {
            _Db4oManager.Delete(entity);            
        }

        public IList<T> GetAll()
        {
            return GetQuery().ToList();
        }

        public void Commit()
        {
            _Db4oManager.Commit();
        }
    }
}

