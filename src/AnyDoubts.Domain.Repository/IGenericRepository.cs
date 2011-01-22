using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;

namespace AnyDoubts.Domain.Repositoy
{
    public interface IGenericRepository<T>
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
