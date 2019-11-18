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
        public ICollection<DLH_User> loadUser(string firstName, string lastName, string group)
        {
            var usersList = Context.tblUser
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
            if (usersList.Count > 0)
                return usersList;
            else
            {
                return new List<DLH_User>() { saveNewUser(firstName, lastName, group) };
            }
        }

        /// <summary>
        /// Save or add user
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="group">Group</param>
        private DLH_User saveNewUser(string firstName, string lastName, string group)
        {
            var newUser = new DLH_User() {  FirstName = firstName, LastName = lastName, Group = group };
            Context.tblUser.Add(new tblUser() {  FirstName = newUser.FirstName, LastName = newUser.LastName, Group = newUser.Group});
            Context.SaveChanges();
            return newUser;
        }

        public ICollection<DLH_User> loadUsers(string NameFilter = "", string GroupFilter = "")
        {
            return Context.tblUser
                .Select(u => new DLH_User()
                {
                    ID = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Group = u.Group
                })
                .ToList();
        }
    }
}
