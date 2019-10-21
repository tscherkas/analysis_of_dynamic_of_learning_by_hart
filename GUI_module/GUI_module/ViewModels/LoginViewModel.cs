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

namespace GUI_module.ViewModels
{
    public class LoginViewModel : IViewModel
    {
        public User User { get; set; }

        public LoginViewModel()
        {

        }
        public LoginViewModel(User user,
            INavigationService navigationService)
        {
            this.Login = new DelegateCommand<object>(this.OnLogin);
            this.navigationService = navigationService;
            User = user;
        }

        private void OnLogin(object obj)
        {
            //User.IsAdmin = (bool)obj;
            if (!User.IsAdmin)
            {
                User.saveOrUpdate();
                navigationService.navigateToTests();
            }
        }

        public ICommand Login { get; set; }
        public ICommand ShowTheory { get; set; }
        public ICommand ShowUserTests { get; set; }

        private INavigationService navigationService;
        
    }
}
