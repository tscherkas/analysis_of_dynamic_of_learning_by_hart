using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLH_BusinessLibrary
{
   
    public class Statistic
    {
        public long ID { get; set; }
        public User User { get; set; }
        public int Pause { get; set; }
        public int Interval { get; set; }
        public int CyclesCount { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
