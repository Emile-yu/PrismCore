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

        public int Add<TEntity>(TEntity obj) where TEntity : class
        {
            return _baseDal.Add<TEntity>(obj);
        }

        public TEntity Find<TEntity>(Expression<Func<TEntity, bool>> funcWhere) where TEntity : class
        {
            return _baseDal.Query<TEntity>(funcWhere);
        }

        public IEnumerable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> funcWhere) where TEntity : class
        {
            return _baseDal.QueryAll<TEntity>(funcWhere);
        }

        public TEntity Query<TEntity>(TEntity obj) where TEntity : class
        {
            return _baseDal.Query<TEntity>(obj);
        }
    }
}
