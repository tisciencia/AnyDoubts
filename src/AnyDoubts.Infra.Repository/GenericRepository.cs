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
using AnyDoubts.Domain.Repositoy;

namespace AnyDoubts.Infra.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
    {
        private IObjectContainer _Db4oManager;

        public GenericRepository()
        {
            _Db4oManager = ContainerFactory.GetObjectContainerManager();            
        }       

        private IQueryable<T> GetQuery()
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

        public T QueryByExample(T entity)
        {
            var result = _Db4oManager.QueryByExample(entity);
            return (T)result.Next();
        }

        public void Commit()
        {
            _Db4oManager.Commit();
        }
    }
}

