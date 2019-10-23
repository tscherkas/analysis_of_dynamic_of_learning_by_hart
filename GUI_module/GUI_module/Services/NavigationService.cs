using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_module.ViewModels;

namespace GUI_module.Services
{
    class NavigationService : INavigationService
    {
        public void setupContainer(IViewContainer container, IViewModel model = null)
        {
            this.container = container;
            if (model == null)
                model = IocKernel.Get<LoginViewModel>();
            container.ViewModel = model;
        }

        public void navigateToLogin()
        {
            container.ViewModel = IocKernel.Get<LoginViewModel>();
        }

        public void navigateToTests(bool adminAccess = false)
        {
            if (adminAccess)
            {
                container.ViewModel = IocKernel.Get<EditTestsViewModel>();
            }
            else
            {
                container.ViewModel = IocKernel.Get<TestsViewModel>();
            }
        }

        public void navigateToAdminMenu()
        {
            container.ViewModel = IocKernel.Get<AdminStartWindowViewModel>();
        }

        private IViewContainer container;

    }
}
