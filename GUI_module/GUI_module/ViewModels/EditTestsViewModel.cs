using DLH_Interfaces;
using GUI_module.Models;
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
    public class EditTestsViewModel : BaseViewModel
    {
        public IEnumerable<Test> Tests { get; set; }    
        public EditTestsViewModel(ISurveyService surveyService,
            INavigationService navigationService):
            base(navigationService)
        {
            this.surveyService = surveyService;
            EditTest = new DelegateCommand<object>(this.OnEditTest);
            loadSurveys();
        }

        public ICommand EditTest { get; set; }

        private void OnEditTest(object obj)
        {
            navigationService.navigateToLogin();
        }

        private void loadSurveys()
        {
            Tests = surveyService.loadSurveys().Select(
                s => new Test {
                    Name = s.name,
                    Description = s.desription
                });
        }

        private ISurveyService surveyService;
    }
}
