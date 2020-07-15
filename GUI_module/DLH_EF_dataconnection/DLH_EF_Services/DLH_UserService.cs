using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLH_DataTransferObjects;

namespace DLH_EF_dataconnection.DLH_EF_Services
{
    public class DLH_UserService : DLH_Interfaces.IUserService
    {
        /// <summary>
        /// Create a service instance
        /// </summary>
        /// <param name="context">Database context</param>
        public DLH_UserService(DLH_Context context)
        {
            Context = context;
        }

        /// <summary>
        /// Database context
        /// </summary>
        public DLH_Context Context { get; set; }

        /// <summary>
        /// Load a user object by params
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="group">Group</param>
        /// <returns>Collection of users objects</returns>
        public IEnumerable<DLH_User> loadUser(string firstName, string lastName, string group)
        {
            return Context.Users
                .Where(u =>
                    u.FirstName == firstName &&
                    u.LastName == lastName &&
                    u.Group == group)
                .Select(u => new DLH_User()
                {
                    ID = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Group = u.Group
                })
                .ToList();
        }

        /// <summary>
        /// Save or add user
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="group">Group</param>
        private DLH_User saveNewUser(string firstName, string lastName,
                                     string group)
        {
            Context.Users.Add(new User() {
                FirstName = firstName,
                LastName = lastName,
                Group = group
            });
            Context.SaveChanges();
            return new DLH_User
            {
                FirstName = firstName,
                LastName = lastName,
                Group = group
            };
        }

        /// <summary>
        /// Load a list of users which match provided filters.
        /// </summary>
        /// <param name="NameFilter">Name filter.</param>
        /// <param name="GroupFilter">Group filter.</param>
        /// <returns></returns>
        public IEnumerable<DLH_User> loadUsers(string NameFilter = "", string GroupFilter = "")
        {
            return Context.Users
                .Where(u => u.FirstName.IndexOf(NameFilter) != -1 ||
                            u.LastName.IndexOf(NameFilter) != -1 ||
                            u.Group.IndexOf(GroupFilter) != -1)
                .Select(u => new DLH_User()
                {
                    ID = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Group = u.Group
                })
                .ToList();
        }

        public IEnumerable<DLH_User> loadUser(DLH_User user)
        {
            return loadUser(user.FirstName, user.LastName, user.Group);
        }

        public DLH_User getCurrentUser(DLH_User user)
        {
            var usersList = this.loadUser(user);
            if (usersList.Count() > 0)
                return usersList.First();
            else
            {
                return saveNewUser(user.FirstName, user.LastName, user.Group);
            }
        }
    }
}
