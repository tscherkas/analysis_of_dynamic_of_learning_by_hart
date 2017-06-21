using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLH_DataTransferObjects;
using DLH_Interfaces;
using Ninject;

namespace DLH_BusinessLibrary
{
    public class User
    {
        private IUserService userService;
        public User()
        {

        }
        public User(IUserService userService)
        {
            this.userService = userService;
        }
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }
        public bool IsAdmin { get; set; }

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
        public void saveOrUpdate()
        {
            ID = userService.loadUser(FirstName, LastName, Group).First().ID;
        }
    }
}
