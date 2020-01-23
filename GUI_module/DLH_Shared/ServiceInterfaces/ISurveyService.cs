using DLH_DataTransferObjects;
using System.Collections.Generic;

namespace DLH_Interfaces
{
    /// <summary>
    /// Survey service
    /// </summary>
    public interface ISurveyService
    {
        /// <summary>
        /// Load surveys
        /// </summary>
        /// <returns>Surveys objects collection</returns>
        IEnumerable<DLH_Survey> loadSurveys();


        IEnumerable<DLH_Stimulus> loadStimulus();
    }
}
