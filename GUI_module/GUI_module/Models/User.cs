using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_module.Models
{
    public class User//: System.Windows.DependencyObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }
        public bool IsAdmin { get; set; }

    }
}
