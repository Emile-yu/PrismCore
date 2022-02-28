using PrismCore.Server.Domain.Interfaces;
using PrismCore.Server.IServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Server.Server
{
    public class ServerBase : IServerBase
    {
        private readonly IRepositoryBase _baseDal;

        public ServerBase(IRepositoryBase baseDal)
        {
            this._baseDal = baseDal;
        }

        public TEntity Add<TEntity>(TEntity obj) where TEntity : class
        {
            return _baseDal.Insert<TEntity>(obj); //Add<TEntity>(obj);
        }

        public TEntity Find<TEntity>(Expression<Func<TEntity, bool>> funcWhere) where TEntity : class
        {
            return _baseDal.Query<TEntity>(funcWhere).FirstOrDefault();
        }

        public IEnumerable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> funcWhere) where TEntity : class
        {
            return _baseDal.Query<TEntity>(funcWhere);
        }

        public TEntity Query<TEntity>(int id) where TEntity : class
        {
            return _baseDal.Find<TEntity>(id);
        }
    }
}
