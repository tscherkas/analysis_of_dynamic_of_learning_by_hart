using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLH_BusinessLibrary
{
    

    public class Settings
    {
        public long ID { get; set; }
        public Survey Survey { get; set; }
        public int Pause { get; set; }
        public int Interval { get; set; }
    }
}
