using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AnyDoubts.Domain.Repository
{
    public interface IGenericRepository<T> : IRepository
    {
        bool IsStored(T entity);
        T Load(Expression<Func<T, bool>> whereCondition);        
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Commit();
        IList<T> GetAll();
    }
}
