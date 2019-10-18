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
using GUI_module.ViewModels;
using GUI_module.Views;

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
        }
    }
}
