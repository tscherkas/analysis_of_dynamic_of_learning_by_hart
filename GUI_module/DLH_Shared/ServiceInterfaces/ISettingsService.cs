using System.Collections.Generic;

namespace DLH_Interfaces
{
    /// <summary>
    /// Service for tuning surveys settings
    /// </summary>
    public interface ISettingsService
    {
        /// <summary>
        /// Load settings for user
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Collection of settings objects</returns>
        ICollection<DLH_DataTransferObjects.DLH_Settings> loadSettings(DLH_DataTransferObjects.DLH_User user);

        /// <summary>
        /// Load settings by filter string
        /// </summary>
        /// <param name="nameDescriptionFilter">Filter string</param>
        /// <returns>Collection of settings objects</returns>
        ICollection<DLH_DataTransferObjects.DLH_Settings> loadSettingsFiltered(string nameDescriptionFilter = "");

        /// <summary>
        /// Update settings object
        /// </summary>
        /// <param name="newSettings">Settings object</param>
        /// <returns>True if update was successful, in other cases - false</returns>
        bool updateSettings(DLH_DataTransferObjects.DLH_Settings newSettings);

        /// <summary>
        /// Delete settings object
        /// </summary>
        /// <param name="settingsId">Settings object identifier</param>
        /// <param name="deleteSurvey">Flag determines if survey should also be deleted</param>
        /// <returns>True if delete was successful, in other cases - false</returns>
        bool deleteSettings(long settingsId, bool deleteSurvey = false);

        /// <summary>
        /// Update survey
        /// </summary>
        /// <param name="survey">Survey</param>
        /// <returns>True if update was successful, in other cases - false</returns>
        bool updateSurvey(DLH_DataTransferObjects.DLH_Survey survey);

        /// <summary>
        /// Delete survey
        /// </summary>
        /// <param name="surveyId">Survey identifier</param>
        /// <returns>True if delete was successful, in other cases - false</returns>
        bool deleteSurvey(long surveyId);
    }
}
