using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLH_BusinessLibrary
{
    /// <summary>
    /// Answer provided during a test to a specific stimul
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// User object
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Ansver value as a string
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Stimulus object
        /// </summary>
        public Stimulus Stimulus { get; set; }

        /// <summary>
        /// Date of answer
        /// </summary>
        public DateTime Date { get; set; }

    }


    
}
