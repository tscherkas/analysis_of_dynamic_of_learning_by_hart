using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DLH_EF_dataconnection.DLH_EF_Services;
using DLH_Interfaces;
using Ninject.Modules;

namespace GUI_module
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IocKernel.Initialize(new IocConfiguration());
            base.OnStartup(e);
            var mainWindow = IocKernel.Get<Login>();
            mainWindow.Show();
            //ConfigureContainer();
            //ComposeObjects();
            //Current.MainWindow.Show();
        }

        //private void ConfigureContainer()
        //{
        //    this.container = new StandardKernel();
        //    container.Bind<IUserService>().To<DLH_UserService>().InSingletonScope();
        //    container.Bind<DLH_BusinessLibrary.User>().ToSelf().InTransientScope();
        //    DLH_BusinessLibrary.DI_Kernel.container = this.container;
        //}

        //private void ComposeObjects()
        //{
        //    Current.MainWindow = this.container.Get<MainWindow>();
        //    Current.MainWindow.Title = "DI with Ninject";
        //}
    }

    class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<DLH_EF_dataconnection.DLH_Context>().ToSelf().InSingletonScope().WithConstructorArgument("connectionString","name = database");
            Bind<IUserService>().To<DLH_UserService>().InSingletonScope();
            Bind<DLH_BusinessLibrary.User>().ToSelf().InTransientScope();
            Bind<Login>().ToSelf().InSingletonScope();
            Bind<LoginViewModel>().ToSelf().InSingletonScope();
            //Bind<IStorage>().To<Storage>().InSingletonScope(); // Reuse same storage every time

            //Bind<UserControlViewModel>().ToSelf().InTransientScope(); // Create new instance every time
        }
    }
    public static class IocKernel
    {
        private static StandardKernel _kernel;

        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public static void Initialize(params INinjectModule[] modules)
        {
            if (_kernel == null)
            {
                _kernel = new StandardKernel(modules);
            }
        }
    }
}
