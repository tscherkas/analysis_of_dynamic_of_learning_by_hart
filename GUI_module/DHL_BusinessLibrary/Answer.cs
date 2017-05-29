using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLH_BusinessLibrary
{
    public class Answer
    {
        public long ID { get; set; }
        public User User { get; set; }
        public string Value { get; set; }
        public Stimulus Stimulus { get; set; }
        public DateTime Time { get; set; }
    }


    
}
