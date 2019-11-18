using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLH_BusinessLibrary
{
    /// <summary>
    /// Represents a collection of stimuls
    /// </summary>
    public class Survey
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public long ID { get; set; }
        
        /// <summary>
        /// Pause in miliseconds
        /// </summary>
        public int Pause { get; set; }

        /// <summary>
        /// Presentation interval in miliseconds
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// Stimulus collection
        /// </summary>
        public ICollection<Stimulus> stimulus { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Desription { get; set; }
    }
}
