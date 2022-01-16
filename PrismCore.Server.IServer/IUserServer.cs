using PrismCore.Server.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Server.IServer
{
    public interface IUserServer : IServerBase
    {
        List<RoleInfo> GetRolesByUserId(int userId);

        void ResetPassword(int userId);
    }
}
