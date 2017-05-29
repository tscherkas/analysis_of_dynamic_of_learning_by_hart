using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLH_DataTransferObjects;
using DLH_Interfaces;
using Ninject.;

namespace DLH_BusinessLibrary
{
    public class User
    {
        [Injectable]
        public IUserService userService { get; set; }
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }

        public ICollection<User> getAllUsers(string nameFilter = "",
            string groupFilter = "")
        {
            return userService.loadUsers(nameFilter, groupFilter)
                .Select(u => new User()
                {
                    ID = u.ID,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Group = u.Group
                }).ToList();
        }
        public ICollection<User> saveOrUpdateUser(string FirstName,
            string LastName,
            string Group)
        {
            return userService.loadUser(FirstName, LastName,Group)
                .Select(u => new User()
                {
                    ID = u.ID,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Group = u.Group
                }).ToList();
        }
    }
}
