using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Input;

namespace GUI_module
{
    public class MainWindowViewModel
    {

        public string Password { get; set; }

        public MainWindowViewModel()
        {
            this.Login = new DelegateCommand<object>(this.OnLogin);
        }

        private void OnLogin(object obj)
        {
            if(Password!="210901")
                throw new NotImplementedException();
        }

        public ICommand Login { get; set; }
        public ICommand StartQuestionarie { get; set; }
        public ICommand ShowTheory { get; set; }
    }
}
