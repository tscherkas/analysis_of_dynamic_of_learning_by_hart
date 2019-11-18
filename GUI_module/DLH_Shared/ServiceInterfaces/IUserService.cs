using System.Collections.Generic;

namespace DLH_Interfaces
{
    /// <summary>
    /// User service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Load user
        /// </summary>
        /// <param name="FirstName">First name</param>
        /// <param name="LastName">Last name</param>
        /// <param name="Group">Group</param>
        /// <returns>Users collection</returns>
        ICollection<DLH_DataTransferObjects.DLH_User> loadUser(string FirstName, string LastName, string Group);

        /// <summary>
        /// Load users
        /// </summary>
        /// <param name="NameFilter">Filter for name</param>
        /// <param name="GroupFilter">Filter for group</param>
        /// <returns>Users collection</returns>
        ICollection<DLH_DataTransferObjects.DLH_User> loadUsers(string NameFilter = "" , string GroupFilter = "");
    }
}
