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

namespace GUI_module
{
    public class LoginViewModel//: DependencyObject
    {
        public User User { get; set; }

        public LoginViewModel()
        {

        }
        public LoginViewModel(User user)
        {
            this.Login = new DelegateCommand<object>(this.OnLogin);
            User = user;
        }

        private void OnLogin(object obj)
        {
            User.IsAdmin = (bool)obj;
            if (!User.IsAdmin)
            {
                User.saveOrUpdate();
            }
        }

        public ICommand Login { get; set; }
        public ICommand ShowTheory { get; set; }

        
    }
}
