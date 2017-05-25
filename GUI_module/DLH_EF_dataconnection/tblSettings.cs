namespace DLH_EF_dataconnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblSettings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SettingsId { get; set; }

        public long SurveyId { get; set; }

        public TimeSpan? Pause { get; set; }

        public TimeSpan Interval { get; set; }

        public virtual tblSurvey tblSurvey { get; set; }
    }
}
