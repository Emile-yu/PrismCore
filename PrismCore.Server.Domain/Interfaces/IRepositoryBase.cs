using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Server.Domain.Interfaces
{
    public interface IRepositoryBase : IDisposable
    {
        /// <summary>
        /// query entity by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find<T>(int id) where T : class;

        /// <summary>
        /// Query entities by function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class;

        /// <summary>
        /// Insert entity, commit 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        T Insert<T>(T t) where T : class;

        /// <summary>
        /// Insert entity, commit
        /// mutip sql, one connecxion, insert by transaction
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <returns></returns>
        IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class;

        /// <summary>
        /// update entity, commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Update<T>(T t) where T : class;

        /// <summary>
        /// update entities, commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        void Update<T>(IEnumerable<T> tList) where T : class;

        /// <summary>
        /// Delete by id, commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        void Delete<T>(int Id) where T : class;

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Delete<T>(T t) where T : class;

        /// <summary>
        /// Delete entities, commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        void Delete<T>(IEnumerable<T> tList) where T : class;

        /// <summary>
        /// trancaction
        /// </summary>
        void Commit();












        //TEntity Query<TEntity>(Expression<Func<TEntity, bool>> funcWhere) where TEntity : class;

        //IEnumerable<TEntity> QueryAll<TEntity>(Expression<Func<TEntity, bool>> funcWhere) where TEntity : class;

        //TEntity Query<TEntity>(TEntity obj) where TEntity : class;

        //int Add<TEntity>(TEntity obj) where TEntity : class;
    }
}
