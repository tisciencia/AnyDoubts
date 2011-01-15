using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnyDoubts.Domain.Entities;
using System.Linq.Expressions;

namespace AnyDoubts.Repository.Repositories
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Return strongly typed IQueryable
        /// </summary>
        IQueryable<T> GetQuery();

        /// <summary>
        /// Load entity from the repository (always query store)
        /// </summary>
        /// <typeparam name="T">the entity type to load</typeparam>
        /// <param name="where">where condition</param>
        /// <returns>the loaded entity</returns>
        T Load(Expression<Func<T, bool>> whereCondition);

        /// <summary>
        /// Provides explicit loading of object properties
        /// </summary>
        void LoadProperty(T entity, Expression<Func<T, object>> selector);

        /// <summary>
        /// Returns all entities for a given type
        /// </summary>
        /// <returns>All entities</returns>
        List<T> GetAll();

        /// <summary>
        /// Add entity to the repository
        /// </summary>
        /// <param name="entity">the entity to add</param>
        /// <returns>The added entity</returns>
        void Add(T entity);

        /// <summary>
        /// Mark entity to be deleted within the repository
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        void Delete(T entity);
    }
}

