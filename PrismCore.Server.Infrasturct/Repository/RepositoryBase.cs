using Microsoft.EntityFrameworkCore;
using PrismCore.Server.Common.Conntext;
using PrismCore.Server.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Server.Infrasturct.Repository
{
    public class RepositoryBase : IRepositoryBase
    {
        private readonly EFCodeContext _context;

        public RepositoryBase(EFCodeContext context)
        {
            this._context = context;
            _context = context;
        }

        #region interaction avec bdd
        public void Commit()
        {
            this._context.SaveChanges();
        }

        public void Delete<T>(int Id) where T : class
        {
            T t = this.Find<T>(Id);
            if (t == null) throw new Exception("t is null");
            this._context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            //Attach是连接，可以看成从数据库读取出了实体（但没有操作数据库）
            //该方法只与数据库连接1次
            this._context.Set<T>().Attach(t);
            //this._context.Entry(t).State = EntityState.Deleted;
            this._context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                this._context.Set<T>().Attach(t);
                //this._context.Entry(t).State = EntityState.Deleted;
            }
            this._context.Set<T>().RemoveRange(tList);
            this.Commit();
        }

        public T Find<T>(int id) where T : class
        {
            return this._context.Set<T>().Find(id);
        }

        public T Insert<T>(T t) where T : class
        {
            this._context.Set<T>().Add(t);
            this.Commit();
            return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            this._context.Set<T>().AddRange(tList);
            this.Commit();
            return tList;
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            return this._context.Set<T>().Where<T>(funcWhere);
        }

        public void Update<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            this._context.Set<T>().Attach(t);
            this._context.Entry(t).State = EntityState.Modified;
            //this._context.Set<T>().Update(t);
            this.Commit();
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                this._context.Set<T>().Attach(t);
                this._context.Entry(t).State = EntityState.Modified;
            }
            this.Commit();
        }
        #endregion

        public void Dispose()
        {
            if (this._context != null)
            {
                this._context.Dispose();
            }
        }

        //public int Add<TEntity>(TEntity obj) where TEntity : class
        //{
        //    _context.Set<TEntity>().Add(obj);
        //    return _context.SaveChanges();

        //}

        //public TEntity Query<TEntity>(Expression<Func<TEntity, bool>> funcWhere) where TEntity : class
        //{
        //    return _context.Set<TEntity>().Where<TEntity>(funcWhere).FirstOrDefault();
        //}

        //public IEnumerable<TEntity> QueryAll<TEntity>(Expression<Func<TEntity, bool>> funcWhere) where TEntity : class
        //{
        //    return _context.Set<TEntity>().Where<TEntity>(funcWhere);
        //}

        //public TEntity Query<TEntity>(TEntity obj) where TEntity : class
        //{
        //    return _context.Set<TEntity>().Find(obj);
        //}
    }
}
