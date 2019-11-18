using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLH_DataTransferObjects
{
    /// <summary>
    /// User object
    /// </summary>
    public class DLH_User
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        public string Group { get; set; }
    }
}