namespace DLH_EF_dataconnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Survey
    {        
        public Survey()
        {
            Settings = new HashSet<Settings>();
        }

        public long SurveyId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public ICollection<Settings> Settings { get; }

        public StimulusGroup StimulusGroup { get; set; }
    }
}
