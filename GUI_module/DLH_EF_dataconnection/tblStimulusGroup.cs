using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DLH_EF_dataconnection
{
    [Table("tblStimulusGroup")]
    public class tblStimulusGroup
    {
        public tblStimulusGroup()
        {
            Stimulus = new HashSet<tblStimulus>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<tblStimulus> Stimulus { get; set; }
    }
}