using Prism.Commands;
using Prism.Regions;
using PrismCore.Demo.Resources.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PrismCore.Demo.Common
{
    public abstract class ViewModelBase : INavigationAware
    {
        private readonly IUnityContainer _unityContainer;
        private readonly IRegionManager _regionManager;

        public string PageTitle { get; set; } = "Tag";

        public bool IsCanClose { get; set; } = true;

        private string NavUri { get; set; }

        public DelegateCommand CloseCommand => new DelegateCommand(() =>
        {
            //根据uri获取对应的已注册对象名称
            var obj = _unityContainer.Registrations.FirstOrDefault(o => o.Name == NavUri);
            string name = obj.MappedToType.Name;
            //根据对象名称从region的views里面找到对象
            if (!string.IsNullOrEmpty(name))
            {
                var region = _regionManager.Regions[RegionNames.MainContentTabRegion];
                var view = region.Views.FirstOrDefault(v => v.GetType().Name == name);

                //把这个对象从region的views里移除
                if (view != null)
                {
                    region.Remove(view);
                }
            }
        });

        public DelegateCommand RefreshCommand => new DelegateCommand(Refresh);
        protected abstract void Refresh();

        public DelegateCommand AddCommand => new DelegateCommand(AddItem);

        protected abstract void AddItem();

        public ViewModelBase(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            this._unityContainer = unityContainer;
            this._regionManager = regionManager;
            this.Refresh();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            NavUri = navigationContext.Uri.ToString();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
