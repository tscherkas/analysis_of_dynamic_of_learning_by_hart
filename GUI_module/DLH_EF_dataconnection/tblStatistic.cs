namespace DLH_EF_dataconnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblStatistic")]
    public partial class tblStatistic
    {
        public tblStatistic()
        {
            tblAnswers = new HashSet<tblAnswer>();
        }
        public long UserId { get; set; }
        
        public long Date { get; set; }

        public long NumberOfCycles { get; set; }
        
        public TimeSpan Pause { get; set; }

        public TimeSpan Interval { get; set; }

        [Required]
        [StringLength(100)]
        public string DynamicData { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StatisticId { get; set; }

        public virtual ICollection<tblAnswer> tblAnswers { get; set; }

        public virtual tblUser tblUser { get; set; }
    }
}
