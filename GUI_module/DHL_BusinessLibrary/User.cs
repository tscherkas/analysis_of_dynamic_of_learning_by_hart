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
    /// <summary>
    /// User object
    /// </summary>
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
        /// <summary>
        /// Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Property indicates if user is admin
        /// </summary>
        public bool IsAdmin { get; set; }

    }
}
