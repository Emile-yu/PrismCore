using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismCore.Demo.Modules.MainModule.ViewModels;
using PrismCore.Demo.Modules.MainModule.Views;
using PrismCore.Demo.Resources.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Demo.Modules.MainModule
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<RegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.LeftMenuTreeContentRegion, typeof(TreeMenuView));
            regionManager.RegisterViewWithRegion(RegionNames.MainHeaderContentRegion, typeof(MainHeaderView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<TreeMenuView>();
        }
    }
}
