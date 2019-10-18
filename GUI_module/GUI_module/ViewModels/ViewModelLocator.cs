using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_module.ViewModels
{
    public class ViewModelLocator
    {
        public LoginViewModel LoginViewModel { get { return IocKernel.Get<LoginViewModel>(); } }
    }
}
