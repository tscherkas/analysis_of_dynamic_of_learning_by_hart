using System.Collections.Generic;

namespace DLH_DataTransferObjects
{
    /// <summary>
    /// Survey object
    /// </summary>
    public class DLH_Survey
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Pause interval in miliseconds
        /// </summary>
        public int pause { get; set; }

        /// <summary>
        /// Presentation interval in miliseconds
        /// </summary>
        public int interval { get; set; }

        /// <summary>
        /// Answers collections
        /// </summary>
        public IEnumerable<DLH_Stimulus> answers { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string desription { get; set; }
    }
}