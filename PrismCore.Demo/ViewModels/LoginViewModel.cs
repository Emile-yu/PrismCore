using Prism.Commands;
using Prism.Mvvm;
using PrismCore.Demo.Entity;
using PrismCore.Demo.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PrismCore.Demo.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private string _userName = "admin";
        private string _errMsg;
        private string _password;
        private readonly ILoginBLL _loginBLL;
        private readonly ISignInBLL _signInBLL;

        public LoginViewModel(ILoginBLL loginBLL, ISignInBLL signInBLL)
        {
            this._loginBLL = loginBLL;
            this._signInBLL = signInBLL;
        }

        public bool IsErrorVisible
        {
            get
            {
                return !String.IsNullOrEmpty(ErrMsg);
            }
        }
        
        public string UserName
        {
            get { return _userName; }
            set { SetProperty<string>(ref _userName, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty<string>(ref _password, value); }
        }

        public string ErrMsg
        {
            get { return _errMsg; }
            set 
            { 
                SetProperty<string>(ref _errMsg, value);
                this.RaisePropertyChanged(nameof(IsErrorVisible));
            }
        }

        public ICommand LoginCommand
        {
            get => new DelegateCommand<object>(OnLogin);
            
        }

        public ICommand SignInCommand
        {
            get => new DelegateCommand<object>(OnSignIn);
        }

        private void OnSignIn(object obj)
        {
            try
            {
                ErrMsg = "";
                if (string.IsNullOrEmpty(this.UserName))
                {
                    ErrMsg = "Please input UserName";
                    return;
                }
                if (string.IsNullOrEmpty(this.Password))
                {
                    ErrMsg = "Please input Password";
                    return;
                }

                var result = _signInBLL.SingIn(new UserSignInEntity { UserName = UserName, Password = Password}).GetAwaiter().GetResult();
                ErrMsg = "Successful sign in";
                if (result != null)
                {
                    //关闭登录窗口
                    (obj as Window).DialogResult = true;

                }
                else
                {
                    this.ErrMsg = "Login fail, please check your username or password";
                }
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                throw new Exception(ex.Message);
            }
        }

        private void OnLogin(object obj)
        {
            try
            {
                ErrMsg = "";
                if (string.IsNullOrEmpty(this.UserName))
                {
                    ErrMsg = "Please input UserName";
                    return;
                }
                if (string.IsNullOrEmpty(this.Password))
                {
                    ErrMsg = "Please input Password";
                    return;
                }

                bool result =_loginBLL.Login(UserName, Password).GetAwaiter().GetResult();

                if (result)
                {
                    //关闭登录窗口
                    (obj as Window).DialogResult = true;

                }
                else
                {
                    ErrMsg = "Please check your username or password";
                    return;
                }
            }
            catch (Exception)
            {

                ErrMsg = "Fail to access server";
            }
        }
    }
}
