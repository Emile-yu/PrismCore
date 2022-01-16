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
    public class MenuServer : ServerBase, IMenuServer
    {
        private readonly IRepositoryBase _baseDal;

        public MenuServer(IRepositoryBase baseDal) : base(baseDal)
        {
            
        }
        public List<MenuInfo> GetAllMenus()
        {
            return base.FindAll<MenuInfo>(o => o.State == 1).ToList();
        }

        public List<MenuInfo> GetMenuByRoleId(int roleId)
        {
            //todo
            var roles = base.FindAll<RoleInfo>(o => o.State == 1 && o.RoleId == roleId);

            return GetAllMenus();
        }

        public List<MenuInfo> GetMenuByUserId(int userId)
        {
            //todo
            // user role => 1对1的关系
            var user = base.Find<UserRole>(o => o.UserId == userId);

            var rolemenus = base.FindAll<RoleMenu>(o => o.RoleId == user.RoleId);

            var menus = GetAllMenus();

            // role menu => 1对n的关系
            List<MenuInfo> result = new List<MenuInfo>();
            foreach (var item in rolemenus)
            {
                var res = menus.Where(o => o.MenuId == item.MenuId).FirstOrDefault();
                if (res != null)
                {
                    result.Add(res);
                }
            }

            return result;
        }

        public void SaveMenu(string data)
        {
            var value = Newtonsoft.Json.JsonConvert.DeserializeObject<MenuInfo>(data);
            //todo
            // MenuId
            // update or add
            base.Add<MenuInfo>(value);
        }
    }
}
