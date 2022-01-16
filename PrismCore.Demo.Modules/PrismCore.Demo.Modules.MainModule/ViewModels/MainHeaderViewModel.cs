using Prism.Mvvm;
using PrismCore.Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Demo.Modules.MainModule.ViewModels
{
    public class MainHeaderViewModel : BindableBase
    {
        public string CurrentUserName { get; set; }
        public MainHeaderViewModel()
        {
            if (GlobalEntity.CurrentUserInfo != null)
            {
                CurrentUserName = GlobalEntity.CurrentUserInfo.Username;
            }
        }
    }
}
