using DLH_DataTransferObjects;
using DLH_BusinessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_module.Helpers
{
    public static class UserHelper
    {
        public static DLH_User ToTransferObject(this User user) => new DLH_User
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Group = user.Group,
            ID = user.ID
        };
        public static User ToBusinessObject(this DLH_User user) => new User
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Group = user.Group,
            ID = user.ID
        };
    }
}
