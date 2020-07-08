namespace DLH_EF_dataconnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAnswer")]
    public partial class tblAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AnswerId { get; set; }


        public DateTime AnswerDateTime { get; set; }

        public long? StimulusId { get; set; }

        public long? StatisticId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Value { get; set; }

        public virtual tblStimulus tblStimulus { get; set; }

        public virtual tblStatistic tblStatistic { get; set; }
        
    }
}
