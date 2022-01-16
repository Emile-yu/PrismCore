using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using PrismCore.Demo.IBLL;
using PrismCore.Demo.Modules.BaseModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrismCore.Demo.Modules.BaseModule.ViewModels
{
    public class ModifyUserDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "User Info Edit";

        public event Action<IDialogResult> RequestClose;

        public ModifyUserDialogViewModel(IUserBLL userBLL)
        {
            this._userBLL = userBLL;
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            //接受编辑状态 新增/编辑
            //获取用户信息
            MainModel = parameters.GetValue<UserModel>("model");
        }

        private UserModel _mainModel = new UserModel();
        private readonly IUserBLL _userBLL;

        public UserModel MainModel
        {
            get { return _mainModel; }
            set { SetProperty<UserModel>(ref _mainModel, value); }
        }

        public ICommand CancelCommand => new DelegateCommand(() =>
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        });

        public ICommand ConfirmCommand => new DelegateCommand(() =>
        {
            //_userBLL.SaveUser(new Entity.UserEntity
            //{
            //    Id = MainModel.UserId,
            //    Username = MainModel.UserName,
            //    RealName = MainModel.RealName,
            //    UserIcon = "",
            //    Password = MainModel.Password,

            //});
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        });
    }
}
