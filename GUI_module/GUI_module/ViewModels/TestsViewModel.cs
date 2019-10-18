using DLH_Interfaces;
using GUI_module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_module.ViewModels
{
    public class TestsViewModel : IViewModel
    {
        public IEnumerable<Test> Tests { get; set; }    
        public TestsViewModel(ISurveyService surveyService)
        {
            this.surveyService = surveyService;
            loadSurveys();
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
