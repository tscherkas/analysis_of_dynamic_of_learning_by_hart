using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLH_EF_dataconnection
{
    public class DLH_EF_Initializer : DropCreateDatabaseIfModelChanges<DLH_Context>
    {
        protected override void Seed(DLH_Context context)
        {
            FillUsers(context);
            FillStimulusGroups(context);
            FillStimulus(context);
            FillSurveys(context);
            FillSurveySettings(context);
            FillStatistics(context);
            FillAnswers(context);

            base.Seed(context);
        }

        private static void FillUsers(DLH_Context context)
        {
            var users = new List<User>();

            users.Add(new User()
            {
                FirstName = "Ivan",
                LastName = "Oblomov",
                Group = "210901"
            });
            users.Add(new User()
            {
                FirstName = "Petr",
                LastName = "Svidler",
                Group = "210901"
            });
            users.Add(new User()
            {
                FirstName = "Anastasiya",
                LastName = "Kamockaya",
                Group = "210902"
            });
            users.Add(new User()
            {
                FirstName = "Alexandr",
                LastName = "Bionov",
                Group = "210902"
            });

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private void FillStimulusGroups(DLH_Context context)
        {
            var stimulusGroups = new List<StimulusGroup>();

            stimulusGroups.Add(new StimulusGroup()
            {
                Name = "Images"                
            });
            stimulusGroups.Add(new StimulusGroup()
            {
                Name = "Text"
            });
            stimulusGroups.Add(new StimulusGroup()
            {
                Name = "Letters"
            });
            stimulusGroups.Add(new StimulusGroup()
            {
                Name = "Images with text"
            });
            stimulusGroups.Add(new StimulusGroup()
            {
                Name = "Text 2"
            });

            context.StimulusGroups.AddRange(stimulusGroups);
            context.SaveChanges();
        }

        private void FillStimulus(DLH_Context context)
        {
            var stimulusGroups = context.StimulusGroups.AsEnumerable();
            foreach (var group in stimulusGroups)
            {
                context.Stimulus.Add(new Stimulus()
                {
                    StimulusGroupId = group.Id,
                    DocumentPath = "Pit",
                    Value = group.Name + "_Tree"
                });
                context.Stimulus.Add(new Stimulus()
                {
                    StimulusGroupId = group.Id,
                    DocumentPath = "Pit",
                    Value = group.Name + "_Flower"
                });
                context.Stimulus.Add(new Stimulus()
                {
                    StimulusGroupId = group.Id,
                    DocumentPath = "Pit",
                    Value = group.Name + "_Human"
                });
            }
            context.SaveChanges();
        }

        private void FillSurveys(DLH_Context context)
        {
            var stimulusGroups = context.StimulusGroups.AsEnumerable();
            var surveys = new List<Survey>();

            foreach (var group in stimulusGroups)
            {
                surveys.Add(new Survey()
                {
                    Name = group.Name + " (serial)",
                    Description = "Serial survey",
                    StimulusGroup = group
                });

                surveys.Add(new Survey()
                {
                    Name = group.Name + " (parallel)",
                    Description = "Parallel survey",
                    StimulusGroup = group
                });
            }

            context.Surveys.AddRange(surveys);
            context.SaveChanges();
        }

        private void FillSurveySettings(DLH_Context context)
        {
            var surveys = context.Surveys.AsEnumerable();
            var surveySettings = new List<Settings>();

            foreach(var survey in surveys)
            {
                surveySettings.Add(new Settings()
                {
                    SurveyId = survey.SurveyId,
                    Interval = new TimeSpan(
                        0,
                        0,
                        survey.Name.IndexOf("parallel") >= 0 ? 50 : 5),
                    Pause =  new TimeSpan(
                        0,
                        0,
                        survey.Name.IndexOf("parallel") >= 0 ? 0 : 2)
                });
            }

            context.Settings.AddRange(surveySettings);
            context.SaveChanges();
        }

        private void FillStatistics(DLH_Context context)
        {
            var users = context.Users.AsEnumerable();
            var surveys = context.Surveys.AsEnumerable();

            var statistics = new List<Statistic>();
            foreach (var user in users)
            {
                foreach (var survey in surveys)
                {                    
                    statistics.Add(new Statistic()
                    {
                        SurveyId = survey.SurveyId,
                        User = user,
                        Date = DateTime.Now,
                        DynamicData = ";;;;",
                        NumberOfCycles = 3
                    });
                }
            }
            context.Statistics.AddRange(statistics);
            context.SaveChanges();
        }

        private void FillAnswers(DLH_Context context)
        {
            var statistics = context.Statistics.AsEnumerable();
            var answers = new HashSet<Answer>();
            foreach (var statistic in statistics)
            {
                foreach (var stimulus in
                    context.Stimulus.AsEnumerable().Where(
                        s => 
                        s.StimulusGroupId == statistic.Survey.StimulusGroup.Id
                        ))
                {
                    answers.Add(
                        new Answer()
                        {
                            StatisticId = statistic.StatisticId,
                            AnswerDateTime = DateTime.Now.AddMinutes(-5),
                            StimulusId = stimulus.StimulusId,
                            Value = stimulus.Value + "_"
                        });
                    answers.Add(
                        new Answer()
                        {
                            StatisticId = statistic.StatisticId,
                            AnswerDateTime = DateTime.Now.AddMinutes(-4),
                            StimulusId = stimulus.StimulusId,
                            Value = stimulus.Value + "__"
                        });
                    answers.Add(
                        new Answer()
                        {
                            StatisticId = statistic.StatisticId,
                            AnswerDateTime = DateTime.Now.AddMinutes(-3),
                            StimulusId = stimulus.StimulusId,
                            Value = stimulus.Value
                        });
                }
            }

            context.Answers.AddRange(answers);
            context.SaveChanges();
        }
    }
}
