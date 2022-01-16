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
        }

        public int Add<TEntity>(TEntity obj) where TEntity : class
        {
            _context.Set<TEntity>().Add(obj);
            return _context.SaveChanges();

        }

        public TEntity Query<TEntity>(Expression<Func<TEntity, bool>> funcWhere) where TEntity : class
        {
            return _context.Set<TEntity>().Where<TEntity>(funcWhere).FirstOrDefault();
        }

        public IEnumerable<TEntity> QueryAll<TEntity>(Expression<Func<TEntity, bool>> funcWhere) where TEntity : class
        {
            return _context.Set<TEntity>().Where<TEntity>(funcWhere);
        }

        public TEntity Query<TEntity>(TEntity obj) where TEntity : class
        {
            return _context.Set<TEntity>().Find(obj);
        }
    }
}
