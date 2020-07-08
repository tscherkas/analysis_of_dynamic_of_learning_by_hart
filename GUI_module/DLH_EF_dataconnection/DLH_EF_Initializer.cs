using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLH_EF_dataconnection
{
    public class DLH_EF_Initializer : DropCreateDatabaseAlways<DLH_Context>
    {
        protected override void Seed(DLH_Context context)
        {
            FillUsers(context);
            FillStimulusGroups(context);
            FillSurveys(context);
            FillSurveySettings(context);
            //FillAnswerStatistics(context);

            base.Seed(context);
        }

        private static void FillUsers(DLH_Context context)
        {
            var users = new List<tblUser>();

            users.Add(new tblUser()
            {
                FirstName = "Ivan",
                LastName = "Oblomov",
                Group = "210901"
            });
            users.Add(new tblUser()
            {
                FirstName = "Petr",
                LastName = "Svidler",
                Group = "210901"
            });
            users.Add(new tblUser()
            {
                FirstName = "Anastasiya",
                LastName = "Kamockaya",
                Group = "210902"
            });
            users.Add(new tblUser()
            {
                FirstName = "Alexandr",
                LastName = "Bionov",
                Group = "210902"
            });

            context.tblUser.AddRange(users);
            context.SaveChanges();
        }

        private void FillStimulusGroups(DLH_Context context)
        {
            var stimulusGroups = new List<tblStimulusGroup>();

            stimulusGroups.Add(new tblStimulusGroup()
            {
                Name = "Images",
                Stimulus = new HashSet<tblStimulus>()
                {
                    new tblStimulus()
                    {
                        Value = "IMG_Tree"
                    },
                    new tblStimulus()
                    {
                        Value = "IMG_Flower"
                    },
                    new tblStimulus()
                    {
                        Value = "IMG_Human"
                    }
                }
            });
            stimulusGroups.Add(new tblStimulusGroup()
            {
                Name = "Text",
                Stimulus = new HashSet<tblStimulus>()
                {
                    new tblStimulus()
                    {
                        Value = "Tree"
                    },
                    new tblStimulus()
                    {
                        Value = "Flower"
                    },
                    new tblStimulus()
                    {
                        Value = "Human"
                    }
                }
            });
            stimulusGroups.Add(new tblStimulusGroup()
            {
                Name = "Letters",
                Stimulus = new HashSet<tblStimulus>()
                {
                    new tblStimulus()
                    {
                        Value = "A"
                    },
                    new tblStimulus()
                    {
                        Value = "Z"
                    },
                    new tblStimulus()
                    {
                        Value = "B"
                    }
                }
            });
            stimulusGroups.Add(new tblStimulusGroup()
            {
                Name = "Images with text",
                Stimulus = new HashSet<tblStimulus>()
                {
                    new tblStimulus()
                    {
                        Value = "IMG_Tree_text"
                    },
                    new tblStimulus()
                    {
                        Value = "IMG_Flower_text"
                    },
                    new tblStimulus()
                    {
                        Value = "IMG_Human_text"
                    }
                }
            });
            stimulusGroups.Add(new tblStimulusGroup()
            {
                Name = "Text 2",
                Stimulus = new HashSet<tblStimulus>()
                {
                    new tblStimulus()
                    {
                        Value = "Pit"
                    },
                    new tblStimulus()
                    {
                        Value = "Iren"
                    },
                    new tblStimulus()
                    {
                        Value = "Iron"
                    }
                }
            });

            context.tblStimulusGroup.AddRange(stimulusGroups);
            context.SaveChanges();
        }

        private void FillSurveys(DLH_Context context)
        {
            var stimulusGroups = context.tblStimulusGroup.AsEnumerable();
            var surveys = new List<tblSurvey>();

            foreach (var group in stimulusGroups)
            {
                surveys.Add(new tblSurvey()
                {
                    Name = group.Name + " (serial)",
                    Description = "Serial survey",
                    StimulusGroup = group
                });

                surveys.Add(new tblSurvey()
                {
                    Name = group.Name + " (parallel)",
                    Description = "Parallel survey",
                    StimulusGroup = group
                });
            }

            context.tblSurvey.AddRange(surveys);
            context.SaveChanges();
        }

        private void FillSurveySettings(DLH_Context context)
        {
            var surveys = context.tblSurvey.AsEnumerable();
            var surveySettings = new List<tblSettings>();

            foreach(var survey in surveys)
            {
                surveySettings.Add(new tblSettings()
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

            context.tblSettings.AddRange(surveySettings);
            context.SaveChanges();
        }

        private void FillAnswerStatistics(DLH_Context context)
        {
            var users = context.tblUser.AsEnumerable();
            var surveys = context.tblSurvey.AsEnumerable();

            var statistics = new List<tblStatistic>();
            foreach(var user in users)
            {
                foreach (var survey in surveys)
                {
                    foreach (var stimulus in survey.StimulusGroup.Stimulus)
                    {
                        List<tblAnswer> answersList = new List<tblAnswer>();
                        answersList.Add(
                            new tblAnswer()
                            {
                                AnswerDateTime = DateTime.Now.AddMinutes(-5),
                                StimulusId = stimulus.StimulusId,
                                Value = stimulus.Value + "_"
                            });
                        answersList.Add(
                            new tblAnswer()
                            {
                                AnswerDateTime = DateTime.Now.AddMinutes(-4),
                                StimulusId = stimulus.StimulusId,
                                Value = stimulus.Value + "__"
                            });
                        answersList.Add(
                            new tblAnswer()
                            {
                                AnswerDateTime = DateTime.Now.AddMinutes(-3),
                                StimulusId = stimulus.StimulusId,
                                Value = stimulus.Value
                            });

                        statistics.Add(new tblStatistic()
                        {
                            SurveyId = survey.SurveyId,
                            UserId = user.UserId,
                            tblAnswers = answersList,                            
                            Date = DateTime.Now,
                            DynamicData = ";;;;" + stimulus.Value,
                            NumberOfCycles = 3                           
                        });
                    }
                }
            }              
        }
    }
}
