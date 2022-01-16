using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using PrismCore.Demo.BLL;
using PrismCore.Demo.DAL;
using PrismCore.Demo.IBLL;
using PrismCore.Demo.IDAL;
using PrismCore.Demo.Modules.BaseModule;
using PrismCore.Demo.Modules.MainModule;
using PrismCore.Demo.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace PrismCore.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
       
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            var login = Container.Resolve<LoginView>();
            bool? res = login.ShowDialog();
            if (res.HasValue && res.Value)
            {
                base.InitializeShell(shell);
            }
            else
            {
                Application.Current.Shutdown();
            }

        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<Dispatcher>(() => Application.Current.Dispatcher);
            //throw new NotImplementedException();
            containerRegistry.RegisterSingleton<ILoginDAL, LoginDAL>();
            containerRegistry.RegisterSingleton<ILoginBLL, LoginBLL>();
            containerRegistry.RegisterSingleton<IUserDAL, UserDAL>();
            containerRegistry.RegisterSingleton<IUserBLL, UserBLL>();


            containerRegistry.RegisterSingleton<IWebAPI, WebAPI>();
            containerRegistry.RegisterSingleton<ISignInDAL, SignInDAL>();
            containerRegistry.RegisterSingleton<ISignInBLL, SignInBLL>();

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //动态扫描
            moduleCatalog.AddModule<MainModule>();
            moduleCatalog.AddModule<BaseModule>();
        }       
    }
}
