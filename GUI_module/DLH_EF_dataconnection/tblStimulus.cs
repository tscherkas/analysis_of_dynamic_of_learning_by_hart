namespace DLH_EF_dataconnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblStimulus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblStimulus()
        {
            tblAnswer = new HashSet<tblAnswer>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StimulusId { get; set; }

        [Required]
        [StringLength(1000)]
        public string DocumentPath { get; set; }

        [Required]
        [StringLength(1000)]
        public string Value { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAnswer> tblAnswer { get; set; }
        
    }
}
