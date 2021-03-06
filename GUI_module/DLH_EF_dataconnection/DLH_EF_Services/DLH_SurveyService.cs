﻿using DLH_DataTransferObjects;
using DLH_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLH_EF_dataconnection.DLH_EF_Services
{
    /// <summary>
    /// Service for surveys
    /// </summary>
    public class DLH_SurveyService : ISurveyService
    {
        /// <summary>
        /// Create a service instance
        /// </summary>
        /// <param name="context">Database context</param>
        public DLH_SurveyService(DLH_Context context)
        {
            Context = context;
        }

        /// <summary>
        /// Database context
        /// </summary>
        public DLH_Context Context { get; set; }

        /// <summary>
        /// Load list of surveys
        /// </summary>
        /// <returns>Collection of surveys</returns>
        public IEnumerable<DLH_Survey> loadSurveys()
        {
            return Context.Surveys
                .Select(s => new DLH_Survey()
                {
                    ID = s.SurveyId,
                    name = s.Name,
                    desription = s.Description
                });
        }

        public IEnumerable<DLH_Stimulus> loadStimulus()
        {
            List<DLH_Stimulus> ret = null;
            var survey = Context.Surveys
                .Select(s => s).First();
            ret = survey.StimulusGroup.Stimulus
                .Select(s => new DLH_Stimulus()
                {
                    ID = s.StimulusId,
                    value = s.DocumentPath
                }).ToList();

            return ret;
        }
    }
}
