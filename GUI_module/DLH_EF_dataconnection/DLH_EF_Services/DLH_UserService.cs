using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLH_DataTransferObjects;

namespace DLH_EF_dataconnection.DLH_EF_Services
{
    class DLH_UserService : DLH_Interfaces.IUserService
    {
        public ICollection<DLH_User> loadUser(string FirstName, string LastName, string Group)
        {
            return null;
        }

        public ICollection<DLH_User> loadUsers(string NameFilter = "", string GroupFilter = "")
        {
            return null;
        }
    }
}
