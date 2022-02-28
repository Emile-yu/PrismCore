using PrismCore.Server.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Server.IServer
{
    public interface IServerBase
    {
        TEntity Find<TEntity>(Expression<Func<TEntity, bool>> funcWhere) where TEntity : class;

        IEnumerable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> funcWhere) where TEntity : class;

        TEntity Query<TEntity>(int id) where TEntity : class;

        TEntity Add<TEntity>(TEntity obj) where TEntity : class;
    }
}
