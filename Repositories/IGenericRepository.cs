using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobberApp.Repositories
{
    public interface IGenericRepository
    {
        // read
        IEnumerable<T> GetAll<T>(
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
        where T : class, IEntity;

        Task<IEnumerable<T>> GetAllAsync<T>(
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where T : class, IEntity;

        IEnumerable<T> Get<T>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where T : class, IEntity;

        Task<IEnumerable<T>> GetAsync<T>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
            where T : class, IEntity;

        T GetOne<T>(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null)
            where T : class, IEntity;

        Task<T> GetOneAsync<T>(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null)
            where T : class, IEntity;

        T GetFirst<T>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null)
            where T : class, IEntity;

        Task<T> GetFirstAsync<T>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null)
            where T : class, IEntity;

        T GetById<T>(object id) where T : class, IEntity;

        Task<T> GetByIdAsync<T>(object id) where T : class, IEntity;

        int GetCount<T>(Expression<Func<T, bool>> filter = null) where T : class, IEntity;

        Task<int> GetCountAsync<T>(Expression<Func<T, bool>> filter = null) where T : class, IEntity;

        bool GetExists<T>(Expression<Func<T, bool>> filter = null) where T : class, IEntity;

        Task<bool> GetExistsAsync<T>(Expression<Func<T, bool>> filter = null) where T : class, IEntity;


        //write
        Task Create<TEntity>(TEntity entity, string createdBy = null) where TEntity : class, IEntity;

        Task Update<TEntity>(TEntity entity, string modifiedBy = null) where TEntity : class, IEntity;

        // void Delete<TEntity>(object id) where TEntity : class, IEntity;

        Task Delete<T>(T entity) where T : class, IEntity;

        void Save();

        Task SaveAsync();

    }       

}