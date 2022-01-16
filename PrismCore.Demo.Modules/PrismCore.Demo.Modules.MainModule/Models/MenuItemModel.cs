using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismCore.Demo.Resources.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrismCore.Demo.Modules.MainModule.Models
{
    public class MenuItemModel : BindableBase
    {
        public string MenuIcon { get; set; }

        public string MenuHeader { get; set; }

        public string TargetView { get; set; }

        private bool _isExpanded;
        private readonly IRegionManager _regionManager;

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { SetProperty<bool>(ref _isExpanded, value); }
        }

        public List<MenuItemModel> Children { get; set; }

        public ICommand OpenViewCommand
        {
            get => new DelegateCommand(() =>
            {
                if ((this.Children == null || this.Children.Count() == 0) &&
                    !string.IsNullOrEmpty(this.TargetView))
                {
                    //页面跳转
                    _regionManager.RequestNavigate(RegionNames.MainContentTabRegion, this.TargetView);
                }
                else
                {
                    this.IsExpanded = !this.IsExpanded;
                }
            });
        }

        public MenuItemModel(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
        }
    }
}
