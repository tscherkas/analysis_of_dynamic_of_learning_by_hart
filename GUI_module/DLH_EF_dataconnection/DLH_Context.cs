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

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Statistic> Statistics { get; set; }
        public virtual DbSet<Stimulus> Stimulus { get; set; }
        public virtual DbSet<StimulusGroup> StimulusGroups { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public static void InitDatabase()
        {
            throw new NotImplementedException();
        }
    }
}
