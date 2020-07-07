namespace DLH_EF_dataconnection
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DLH_Context : DbContext
    {
        public DLH_Context()
            : base("name=database")
        {
            Database.SetInitializer(new DLH_EF_Initializer());
        }
        public DLH_Context(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer(new DLH_EF_Initializer());
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tblAnswer> tblAnswer { get; set; }
        public virtual DbSet<tblSettings> tblSettings { get; set; }
        public virtual DbSet<tblStatistic> tblStatistic { get; set; }
        public virtual DbSet<tblStimulus> tblStimulus { get; set; }
        public virtual DbSet<tblStimulusGroup> tblStimulusGroup { get; set; }
        public virtual DbSet<tblSurvey> tblSurvey { get; set; }
        public virtual DbSet<tblUser> tblUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public static void InitDatabase()
        {
            throw new NotImplementedException();
        }
    }
}
