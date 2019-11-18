using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLH_BusinessLibrary
{
   /// <summary>
   /// Statisstic object for a particular user
   /// </summary>
    public class Statistic
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// User 
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Pause length used in test (miliseconds)
        /// </summary>
        public int Pause { get; set; }

        /// <summary>
        /// Presentation interval used in test (miliseconds)
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// Count of repeatings used to finish test
        /// </summary>
        public int CyclesCount { get; set; }

        /// <summary>
        /// Answers collection
        /// </summary>
        public ICollection<Answer> Answers { get; set; }
    }
}
