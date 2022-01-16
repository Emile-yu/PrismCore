using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Server.Domain.Interfaces
{
    public interface IRepositoryBase
    {

        TEntity Query<TEntity>(Expression<Func<TEntity, bool>> funcWhere) where TEntity : class;

        IEnumerable<TEntity> QueryAll<TEntity>(Expression<Func<TEntity, bool>> funcWhere) where TEntity : class;

        TEntity Query<TEntity>(TEntity obj) where TEntity : class;

        int Add<TEntity>(TEntity obj) where TEntity : class;
    }
}
