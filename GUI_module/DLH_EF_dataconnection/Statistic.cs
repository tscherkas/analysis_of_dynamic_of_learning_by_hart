namespace DLH_EF_dataconnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Statistic
    {
        public Statistic()
        {
            Answers = new HashSet<Answer>();
        }
        
        public long SurveyId { get; set; }

        public DateTime Date { get; set; }

        public long NumberOfCycles { get; set; }
        
        [Required]
        [StringLength(100)]
        public string DynamicData { get; set; }

        public long StatisticId { get; set; }
        
        public Survey Survey { get; set; }

        public User User { get; set; }

        public ICollection<Answer> Answers { get; }

    }
}
