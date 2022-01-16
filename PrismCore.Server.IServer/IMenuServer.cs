using PrismCore.Server.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Server.IServer
{
    public interface IMenuServer : IServerBase
    {
        List<MenuInfo> GetMenuByUserId(int userId);

        List<MenuInfo> GetMenuByRoleId(int roleId);

        List<MenuInfo> GetAllMenus();

        void SaveMenu(string data);
    }
}
