using PrismCore.Server.Common.Models;
using PrismCore.Server.Domain.Interfaces;
using PrismCore.Server.IServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Server.Server
{
    public class UserServer : ServerBase, IUserServer
    {
        public UserServer(IRepositoryBase baseDal) : base(baseDal)
        {
        }

        public List<RoleInfo> GetRolesByUserId(int userId)
        {
            //todo

            var userrole = base.FindAll<UserRole>(o => o.UserId == userId);

            var roles = base.FindAll<RoleInfo>(o => true).ToList();

            // role menu => 1对n的关系
            List<RoleInfo> result = new List<RoleInfo>();
            foreach (var item in userrole)
            {
                var res = roles.Where(o => o.RoleId == item.RoleId).FirstOrDefault();
                if (res != null)
                {
                    result.Add(res);
                }
            }

            return result;
        }

        public void ResetPassword(int userId)
        {
            //throw new NotImplementedException();
        }

        
    }
}
