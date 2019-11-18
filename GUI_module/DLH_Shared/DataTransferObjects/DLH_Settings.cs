namespace DLH_DataTransferObjects
{
    /// <summary>
    /// Survey settings
    /// </summary>
    public class DLH_Settings
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Survey
        /// </summary>
        public DLH_Survey survey { get; set; }

        /// <summary>
        /// Pause interval in miliseconds
        /// </summary>
        public int pause { get; set; }

        /// <summary>
        /// Presentation interval in miliseconds
        /// </summary>
        public int interval { get; set; }
    }
}