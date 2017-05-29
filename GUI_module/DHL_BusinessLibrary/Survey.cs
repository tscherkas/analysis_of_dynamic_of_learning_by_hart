using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLH_BusinessLibrary
{
   
    public class Survey
    {
        public long ID { get; set; }
        public int Pause { get; set; }
        public int Interval { get; set; }
        public ICollection<Stimulus> answers { get; set; }
        public string Name { get; set; }
        public string Desription { get; set; }
    }
}
