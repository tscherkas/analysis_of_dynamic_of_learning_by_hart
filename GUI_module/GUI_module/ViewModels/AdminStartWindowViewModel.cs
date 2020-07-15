using DLH_EF_dataconnection;
using DLH_Interfaces;
using GUI_module.Services;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Data.Entity;

namespace GUI_module.ViewModels
{
    public class AdminStartWindowViewModel: BaseViewModel
    {
        public class UserSurveys
        {
            public string Name { get; set; }
            public string Survey { get; set; }
            public DateTime Date { get; set; }
            public string DynamicData { get; set; }
        }

        private ISurveyService surveyService;

        public ICommand Tests { get; set; }
        public ICommand StimulsGroups { get; set; }
        public ICommand Theory { get; set; }

        public IEnumerable<UserSurveys> UsersSurveys { get; set; }

        public AdminStartWindowViewModel(INavigationService navigationService,
            DLH_EF_dataconnection.DLH_Context context) :
            base(navigationService)
        {
            Tests = new DelegateCommand<object>(goToTests);
            StimulsGroups = new DelegateCommand<object>(goToStimulsGroups);
            Theory = new DelegateCommand<object>(goToTheory);
            InitUsers(context);
        }

        private void InitUsers(DLH_Context context)
        {
            var users = context.Users.Include(u => u.Statistics).AsEnumerable();
            var surveys = context.Surveys.AsEnumerable();
            var statistics = context.Statistics.AsEnumerable();

            //var us1 = from u in users
            //          join st in statistics on u.UserId equals st.UserId into stt
            //               from st in stt.DefaultIfEmpty()                           
            //               select new UserSurveys {
            //                   Name = u.FirstName + u.LastName,
            //                   Survey = st == null ? "" : st.Survey?.Name,
            //                   Date =  st == null ? DateTime.MinValue : st.Date,
            //                   DynamicData = st == null ? "" : st.DynamicData
            //               };

            var us2 = users
                .Select( u => 
                            new UserSurveys
                            {
                                Name = u.FirstName + u.LastName,
                                Survey = "",
                                Date = DateTime.MinValue,
                                DynamicData = u.Statistics.Count(s => s.NumberOfCycles > -1).ToString()
                            });

            UsersSurveys = us2;
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

        public class UserSurveyEqualityComparer : IEqualityComparer<UserSurveys>
        {
            public bool Equals(UserSurveys b1, UserSurveys b2)
            {
                return b1.Name == b2.Name && b1.Survey == b2.Survey && b1.Date == b2.Date;
            }

            public int GetHashCode(UserSurveys bx)
            {
                var hCode = bx.Name + bx.Date.ToString() + bx.DynamicData + bx.Survey;
                return hCode.GetHashCode();
            }
        }
    }
}
