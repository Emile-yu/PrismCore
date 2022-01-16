using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using PrismCore.Demo.Common;
using PrismCore.Demo.IBLL;
using PrismCore.Demo.Modules.BaseModule.Models;
using PrismCore.Demo.Resources.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Unity;

namespace PrismCore.Demo.Modules.BaseModule.ViewModels
{
    public class UserManagementViewModel : ViewModelBase
    {
        private readonly IUnityContainer _unityContainer;
        private readonly IUserBLL _userBLL;

        public ObservableCollection<UserModel> UserList { get; set; } = new ObservableCollection<UserModel>();
        public UserManagementViewModel(IUnityContainer unityContainer, IRegionManager regionManager, IUserBLL userBLL) : base(unityContainer, regionManager)
        {
            this.PageTitle = "User Management";
            this._unityContainer = unityContainer;
            this._userBLL = userBLL;
        }

        protected override void Refresh()
        {
            //用户信息刷新
            UserList.Clear();
            Task.Run(() =>
            {
                //_userBLL.GetAll() => 返回的是Task
                var users = _userBLL.GetAll().GetAwaiter().GetResult();

                foreach (var user in users)
                {
                    UserModel userModel = new UserModel
                    {
                        Index = users.IndexOf(user) + 1,
                        UserId = user.Id,
                        UserName = user.Username,
                        UserIcon = "pack://application:,,,/PrismCore.Demo.Resources;component/Images/cola.png",
                        Password = user.Password,
                        RealName = user.RealName
                    };
                    //用户信息
                    var roles = _userBLL.GetRolesByUserId(user.Id).GetAwaiter().GetResult();
                    roles?.ForEach(o => userModel.Roles.Add(new RoleModel
                    {
                        RoleId = o.roleId,
                        RoleName = o.roleName,
                        State = o.state
                    }));

                    userModel.EditCommand = new DelegateCommand<object>(EditItem);
                    userModel.DeleteCommand = new DelegateCommand<object>(DeleteItem);
                    userModel.RoleCommand = new DelegateCommand<object>(SetRoles);
                    userModel.PwdCommand = new DelegateCommand<object>(SetPassword);

                    _unityContainer.Resolve<Dispatcher>().Invoke(() =>
                    {
                        //跨线程了！
                        UserList.Add(userModel);
                    }); 
                    
                }
            });
        }

        private void SetPassword(object obj)
        {
            Task.Run(async () =>
            {
                await _userBLL.ResetPassword(obj.ToString());
                System.Windows.MessageBox.Show("password has changed", "advertissement");
            });
        }

        private void SetRoles(object obj)
        {
            
        }

        private void DeleteItem(object obj)
        {
            
        }

        private void EditItem(object obj)
        {
            
        }

        protected override void AddItem()
        {
            
        }
    }
}
