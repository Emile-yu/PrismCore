using PrismCore.Server.Common.Models;
using PrismCore.Server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Server.IServer
{
    public interface ILoginServer : IServerBase
    {
        SysUserInfo Login(string username, string password);
    }
}
