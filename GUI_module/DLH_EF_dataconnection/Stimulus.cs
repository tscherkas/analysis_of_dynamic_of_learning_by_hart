namespace DLH_EF_dataconnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Stimulus
    {        
        public Stimulus()
        {
            Answers = new HashSet<Answer>();
        }

        public long StimulusId { get; set; }

        [Required]
        [StringLength(1000)]
        public string DocumentPath { get; set; }

        [Required]
        [StringLength(1000)]
        public string Value { get; set; }

        public long StimulusGroupId { get; set; }

        public StimulusGroup StimulusGroup { get; set; }

        public ICollection<Answer> Answers { get; }

    }
}
