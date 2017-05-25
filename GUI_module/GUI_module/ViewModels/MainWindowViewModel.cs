using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Input;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows;

namespace GUI_module
{
    public class MainWindowViewModel: DependencyObject
    {

        public Models.User User { get; set; }
        
        public MainWindowViewModel()
        {
            User = new Models.User();
            this.Login = new DelegateCommand<object>(this.OnLogin);
        }

        private void OnLogin(object obj)
        {
            User.IsAdmin = (bool)obj;
        }

        public ICommand Login { get; set; }
        public ICommand ShowTheory { get; set; }

        
    }
}
