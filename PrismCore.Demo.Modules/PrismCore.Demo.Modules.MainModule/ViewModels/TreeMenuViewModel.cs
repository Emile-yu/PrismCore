using Prism.Regions;
using PrismCore.Demo.Entity;
using PrismCore.Demo.Modules.MainModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PrismCore.Demo.Modules.MainModule.ViewModels
{
    public class TreeMenuViewModel
    {
        public List<MenuItemModel> Menus { get; set; } = new List<MenuItemModel>();

        private List<MenuEntity> _originMenu = null;
        private readonly IRegionManager _regionManager;

        public TreeMenuViewModel(IRegionManager regionManager)
        {
            _originMenu = GlobalEntity.CurrentUserInfo?.Menus;
            this._regionManager = regionManager;
            this.FillMenus(Menus, 0);
            
        }

        private void FillMenus(List<MenuItemModel> menus, int parentId)
        {
            var sub = _originMenu.Where(o => o.ParentId == parentId).OrderBy(o => o.Index);
            if (sub.Count()>0)
            {
                foreach (var item in sub)
                {
                    MenuItemModel menu = new MenuItemModel(_regionManager)
                    {
                        MenuIcon = item.MenuIcon,
                        MenuHeader = item.MenuHeader,
                        TargetView = item.TargetView
                    };
                    menus.Add(menu);
                    FillMenus(menu.Children = new List<MenuItemModel>(), item.MenuId);
                }
                
            }
            
        }
    }
}
