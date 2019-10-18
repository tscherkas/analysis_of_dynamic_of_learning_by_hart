using DLH_DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLH_Interfaces
{
    public interface IUserService
    {
        ICollection<DLH_DataTransferObjects.DLH_User> loadUser(string FirstName, string LastName, string Group);
        ICollection<DLH_DataTransferObjects.DLH_User> loadUsers(string NameFilter = "" , string GroupFilter = "");
    }
    public interface ISettingsService
    {
        ICollection<DLH_DataTransferObjects.DLH_Settings> loadSettings(DLH_DataTransferObjects.DLH_User user);
        ICollection<DLH_DataTransferObjects.DLH_Settings> loadSettings(string NameDescriptionFilter = "");
        bool updateSettings(DLH_DataTransferObjects.DLH_Settings newSettings);
        bool deleteSettings(long settingsId, bool deleteSurvey = false);
        bool updateSurvey(DLH_DataTransferObjects.DLH_Survey newSettings);
        bool deleteSurvey(long surveyId);
    }
    public interface IStatisticService
    {
        ICollection<DLH_Statistic> loadStatistic(DLH_User user);
        ICollection<DLH_Statistic> loadStatistic(string NameFilter, string GroupFilter, DateTime fromFilter, DateTime toFilter);
        bool saveStatistic(DLH_Statistic statistic);
    }

    public interface ISurveyService
    {
        ICollection<DLH_Survey> loadSurveys();
    }
}
namespace DLH_DataTransferObjects
{
    public class DLH_Answer
    {
        public long ID { get; set; }
        public DLH_User user { get; set; }
        public string value { get; set; }
        public DLH_Stimulus stimulus { get; set; }
        public DateTime time { get; set; }
    }
    public class DLH_Settings
    {
        public long ID { get; set; }
        public DLH_Survey survey { get; set; }
        public int pause { get; set; }
        public int interval { get; set; }
    }
    public class DLH_Statistic
    {
        public long ID { get; set; }
        public DLH_User user { get; set; }
        public int pause { get; set; }
        public int interval { get; set; }
        public int cyclesCount { get; set; }
        public ICollection<DLH_Answer> answers { get; set; }
    }
    public class DLH_Stimulus
    {
        public long ID { get; set; }
        public string value { get; set; }
    }
    public class DLH_Survey
    {
        public long ID { get; set; }
        public int pause { get; set; }
        public int interval { get; set; }
        public ICollection<DLH_Stimulus> answers { get; set; }
        public string name { get; set; }
        public string desription { get; set; }
    }
    public class DLH_User
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }
    }
}