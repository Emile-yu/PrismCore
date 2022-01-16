using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismCore.Demo.Modules.BaseModule.ViewModels;
using PrismCore.Demo.Modules.BaseModule.Views;

namespace PrismCore.Demo.Modules.BaseModule
{
    public class BaseModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<UserManagementView, UserManagementViewModel>();
        }
    }
}