using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLH_BusinessLibrary;
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

        public void navigateToTests()
        {
            if (this.user.IsAdmin)
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

        public void navigateToStimulsGroups()
        {
            container.ViewModel = IocKernel.Get<StimulsCollectionsViewModel>();
        }
        public void setCurrentUser(User user)
        {
            this.user = user;
        }

        public User getCurrentUser()
        {
            return this.user;
        }


        private IViewContainer container;

        private User user;

    }
}
