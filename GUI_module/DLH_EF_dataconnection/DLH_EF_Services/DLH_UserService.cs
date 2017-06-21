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
        public DLH_UserService(DLH_Context context)
        {
            Context = context;
        }
        public DLH_Context Context { get; set; }
        public ICollection<DLH_User> loadUser(string FirstName, string LastName, string Group)
        {
            var usersList = Context.tblUser
                .Where(u =>
                    u.FirstName == FirstName &&
                    u.LastName == LastName &&
                    u.Group == Group)
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
                return new List<DLH_User>() { saveNewUser(FirstName, LastName, Group) };
            }
        }

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
