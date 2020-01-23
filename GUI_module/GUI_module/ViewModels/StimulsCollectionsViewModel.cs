using DLH_BusinessLibrary;
using DLH_Interfaces;
using GUI_module.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_module.Helpers;
using System.Collections.ObjectModel;

namespace GUI_module.ViewModels
{
    public class StimulsCollectionsViewModel : BaseViewModel
    {
        private ISurveyService surveyService;
        private ObservableCollection<Stimulus> stimulus;

        public ObservableCollection<Stimulus> Stimulus
        {
            get => stimulus;
            set
            {
                stimulus = value;
                NotifyPropertyChanged();
            }
        }

        public StimulsCollectionsViewModel(ISurveyService surveyService,
            INavigationService navigationService)
            : base(navigationService)
        {
            this.surveyService = surveyService;
            Stimulus = new ObservableCollection<Stimulus>(
                this.surveyService.loadStimulus().ToBusinessObject());
        }
    }
}
