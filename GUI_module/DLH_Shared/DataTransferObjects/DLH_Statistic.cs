using System.Collections.Generic;

namespace DLH_DataTransferObjects
{
    /// <summary>
    /// Simple statistic storage
    /// </summary>
    public class DLH_Statistic
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public DLH_User user { get; set; }
        
        /// <summary>
        /// Pause interval in miliseconds
        /// </summary>
        public int pause { get; set; }

        /// <summary>
        /// Presentation interval in miliseconds
        /// </summary>
        public int interval { get; set; }

        /// <summary>
        /// Count od repeatings
        /// </summary>
        public int cyclesCount { get; set; }

        /// <summary>
        /// Answers collections
        /// </summary>
        public IEnumerable<DLH_Answer> answers { get; set; }
    }
}