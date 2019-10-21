using GUI_module.Services;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI_module.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged, IViewContainer
    {
        public IViewModel ViewModel
        {
            get
            {
                if (viewModel == null)
                    viewModel = IocKernel.Get<LoginViewModel>(); 
                return viewModel;
            }
            set
            {
                if (viewModel != value) {
                    viewModel = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public ICommand GoToLogin { get; set; }

        public DelegateCommand<IViewModel> GoToView { get; set; }

        public MainViewModel()
        {
            this.GoToLogin = new DelegateCommand<object>(this.OnGoToLogin);
            this.GoToView = new DelegateCommand<IViewModel>(this.OnGoToView);
            IocKernel.Get<INavigationService>().setupContainer(this);
        }

        private void OnGoToLogin(object obj)
        {
            ViewModel = IocKernel.Get<LoginViewModel>();
        }

        private void OnGoToView(IViewModel obj)
        {
            ViewModel = obj;
        }

        public event PropertyChangedEventHandler PropertyChanged;
 
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private IViewModel viewModel;
    }
}
