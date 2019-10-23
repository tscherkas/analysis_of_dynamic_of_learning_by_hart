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
        public MainViewModel MainViewModel { get { return IocKernel.Get<MainViewModel>(); } }
        public TestsViewModel TestsViewModel { get { return IocKernel.Get<TestsViewModel>(); } }
        public EditTestsViewModel EditTestsViewModel { get { return IocKernel.Get<EditTestsViewModel>(); } }
        public AdminStartWindowViewModel AdminStartWindowViewModel { get { return IocKernel.Get<AdminStartWindowViewModel>(); } }
    }
}
