using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DLH_EF_dataconnection
{
    public class StimulusGroup
    {
        public StimulusGroup()
        {
            Stimulus = new HashSet<Stimulus>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Stimulus> Stimulus { get; }
    }
}