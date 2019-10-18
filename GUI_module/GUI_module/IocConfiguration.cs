using DLH_EF_dataconnection.DLH_EF_Services;
using DLH_Interfaces;
using GUI_module.ViewModels;
using GUI_module.Views;
using Ninject.Modules;

namespace GUI_module
{
    public class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<DLH_EF_dataconnection.DLH_Context>().ToSelf().InSingletonScope().WithConstructorArgument("connectionString", "name = database");
            Bind<IUserService>().To<DLH_UserService>().InSingletonScope();
            Bind<DLH_BusinessLibrary.User>().ToSelf().InTransientScope();
            Bind<Login>().ToSelf().InSingletonScope();
            Bind<LoginViewModel>().ToSelf().InSingletonScope();
        }
    }
}