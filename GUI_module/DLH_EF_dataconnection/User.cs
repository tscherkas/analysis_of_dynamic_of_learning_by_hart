namespace DLH_EF_dataconnection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {        
        public User()
        {
            Statistics = new HashSet<Statistic>();
        }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string Group { get; set; }

        public long UserId { get; set; }
        
        public ICollection<Statistic> Statistics { get; }
    }
}
