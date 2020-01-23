using System.Collections.Generic;

namespace DLH_Interfaces
{
    /// <summary>
    /// User service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Load user.
        /// </summary>
        /// <param name="FirstName">First name.</param>
        /// <param name="LastName">Last name.</param>
        /// <param name="Group">Group.</param>
        /// <returns>Users collection.</returns>
        IEnumerable<DLH_DataTransferObjects.DLH_User> loadUser(string FirstName, string LastName, string Group);

        /// <summary>
        /// Load user.
        /// </summary>
        /// <param name="user">User object.</param>
        /// <returns>Users collection.</returns>
        IEnumerable<DLH_DataTransferObjects.DLH_User> loadUser(DLH_DataTransferObjects.DLH_User user);

        /// <summary>
        /// Load users
        /// </summary>
        /// <param name="NameFilter">Filter for name.</param>
        /// <param name="GroupFilter">Filter for group.</param>
        /// <returns>Users collection.</returns>
        IEnumerable<DLH_DataTransferObjects.DLH_User> loadUsers(string NameFilter = "" , string GroupFilter = "");

        /// <summary>
        /// Get current user.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>Updated or created user.</returns>
        DLH_DataTransferObjects.DLH_User getCurrentUser(DLH_DataTransferObjects.DLH_User user);
    }
}
