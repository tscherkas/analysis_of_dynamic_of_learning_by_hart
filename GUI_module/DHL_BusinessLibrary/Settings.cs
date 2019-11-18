using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLH_BusinessLibrary
{
    /// <summary>
    /// Settings object for a specific survey
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Survey object
        /// </summary>
        public Survey Survey { get; set; }

        /// <summary>
        /// Pause length in miliseconds
        /// </summary>
        public int Pause { get; set; }

        /// <summary>
        /// Presentation interval length in miliseconds
        /// </summary>
        public int Interval { get; set; }
    }
}
