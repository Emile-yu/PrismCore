using PrismCore.Server.Common.Models;
using PrismCore.Server.Domain.Interfaces;
using PrismCore.Server.Domain.Models;
using PrismCore.Server.IServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Server.Server
{
    public class LoginServer : ServerBase, ILoginServer
    {
        public LoginServer(IRepositoryBase baseDal) : base(baseDal)
        {
        }

        public SysUserInfo Login(string username, string password)
        {
            return base.Find<SysUserInfo>(o => o.UserName == username && o.Password == password);
        }
    }
}
