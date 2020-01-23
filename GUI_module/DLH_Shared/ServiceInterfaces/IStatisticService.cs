using DLH_DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DLH_Interfaces
{
    /// <summary>
    /// Statistic service
    /// </summary>
    public interface IStatisticService
    {
        /// <summary>
        /// Load statistic for user
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Collection of statistic objects</returns>
        IEnumerable<DLH_Statistic> loadStatistic(DLH_User user);

        /// <summary>
        /// Load statistic filtered
        /// </summary>
        /// <param name="NameFilter">Name filter</param>
        /// <param name="GroupFilter">Group filter</param>
        /// <param name="fromFilter">Minimum date filter</param>
        /// <param name="toFilter">Maximum date filter</param>
        /// <returns>Collection of statistic objects</returns>
        IEnumerable<DLH_Statistic> loadStatistic(string NameFilter, string GroupFilter, DateTime fromFilter, DateTime toFilter);

        /// <summary>
        /// Save statistic
        /// </summary>
        /// <param name="statistic">Statistic object</param>
        /// <returns>True if update was successful, in other cases - false</returns>
        bool saveStatistic(DLH_Statistic statistic);
    }
}
