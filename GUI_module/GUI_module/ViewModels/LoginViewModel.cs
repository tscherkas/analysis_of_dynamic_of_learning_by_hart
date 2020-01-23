using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Input;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows;
using DLH_BusinessLibrary;
using GUI_module.Services;
using System.ComponentModel;
using DLH_Interfaces;
using GUI_module.Helpers;

namespace GUI_module.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public User User { get; set; }

        public LoginViewModel(User user,
            INavigationService navigationService,
            IUserService userService):
            base(navigationService)
        {
            this.Login = new DelegateCommand<object>(this.OnLogin);
            User = user;
            this.userService = userService;
        }

        private void OnLogin(object obj)
        {
            SetupCurrentUser((bool)obj);
            if (navigationService.getCurrentUser().IsAdmin)
            {
                navigationService.navigateToAdminMenu();
            }
            else
            {
                navigationService.navigateToTests();
            }
        }

        private void SetupCurrentUser(bool isAdmin)
        {
            var user = userService.getCurrentUser(User.ToTransferObject())
                .ToBusinessObject();
            user.IsAdmin = isAdmin;
            navigationService.setCurrentUser(user);
        }

        public ICommand Login { get; set; }
        public ICommand ShowTheory { get; set; }
        public ICommand ShowUserTests { get; set; }

        private IUserService userService;

    }
}
