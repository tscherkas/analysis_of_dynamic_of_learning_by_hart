using DLH_DataTransferObjects;
using DLH_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLH_EF_dataconnection.DLH_EF_Services
{
    public class DLH_SurveyService : ISurveyService
    {
        public DLH_SurveyService(DLH_Context context)
        {
            Context = context;
        }
        public DLH_Context Context { get; set; }
        public ICollection<DLH_Survey> loadSurveys()
        {
            return Context.tblSurvey
                .Select(s => new DLH_Survey()
                {
                    ID = s.SurveyId,
                    name = s.Name,
                    desription = s.Description
                }).ToList();
        }
    }
}
