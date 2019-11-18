using System;

namespace DLH_DataTransferObjects
{
    /// <summary>
    /// Answer object
    /// </summary>
    public class DLH_Answer
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
        /// Answer value
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// Stimulus
        /// </summary>
        public DLH_Stimulus stimulus { get; set; }

        /// <summary>
        /// Time
        /// </summary>
        public DateTime time { get; set; }
    }
}