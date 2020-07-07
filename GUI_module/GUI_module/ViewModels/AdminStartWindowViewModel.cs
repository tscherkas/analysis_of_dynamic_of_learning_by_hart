using GUI_module.Services;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI_module.ViewModels
{
    public class AdminStartWindowViewModel: BaseViewModel
    {
        public ICommand Tests { get; set; }
        public ICommand StimulsGroups { get; set; }
        public ICommand Theory { get; set; }

        public AdminStartWindowViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Tests = new DelegateCommand<object>(goToTests);
            StimulsGroups = new DelegateCommand<object>(goToStimulsGroups);
            Theory = new DelegateCommand<object>(goToTheory);
        }

        private void goToTests(object obj)
        {
            navigationService.navigateToTests();
        }
        private void goToStimulsGroups(object obj)
        {
            navigationService.navigateToStimulsGroups();
        }
        private void goToTheory(object obj)
        {
            
        }
    }
}
