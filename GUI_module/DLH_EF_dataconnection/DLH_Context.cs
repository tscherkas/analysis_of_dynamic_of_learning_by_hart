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

        }
        public DLH_Context(string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tblAnswer> tblAnswer { get; set; }
        public virtual DbSet<tblSettings> tblSettings { get; set; }
        public virtual DbSet<tblStatistic> tblStatistic { get; set; }
        public virtual DbSet<tblStimulus> tblStimulus { get; set; }
        public virtual DbSet<tblSurvey> tblSurvey { get; set; }
        public virtual DbSet<tblUser> tblUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblAnswer>()
                .Property(e => e.AnswerDateTime)
                .IsFixedLength();

            modelBuilder.Entity<tblAnswer>()
                .HasKey(e => e.AnswerId);

            modelBuilder.Entity<tblAnswer>()
                .Property(e => e.AnswerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<tblAnswer>()
                .Property(e => e.Value)
                .IsFixedLength();


            modelBuilder.Entity<tblStimulus>()
                .HasKey(e => e.StimulusId);

            modelBuilder.Entity<tblStimulus>()
                .Property(e => e.StimulusId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<tblStimulus>()
                .Property(e => e.DocumentPath)
                .IsFixedLength();

            modelBuilder.Entity<tblSurvey>()
                .HasKey(e => e.SurveyId);

            modelBuilder.Entity<tblSurvey>()
                .Property(e => e.SurveyId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<tblSurvey>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<tblSurvey>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<tblSurvey>()
                .HasMany(e => e.tblSettings)
                .WithRequired(e => e.tblSurvey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStatistic>()
                .HasKey(e => e.StatisticId);

            modelBuilder.Entity<tblStatistic>()
                .Property(e => e.StatisticId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<tblStatistic>()
                .HasMany(e => e.tblAnswers)
                .WithRequired(e => e.tblStatistic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblSurvey>()
                .HasMany(e => e.tblStimulus)
                .WithRequired(e => e.tblSurvey)
                .WillCascadeOnDelete(false);
             
            modelBuilder.Entity<tblUser>()
                .HasKey(e => e.UserId);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<tblUser>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Group)
                .IsFixedLength();
            
            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblStatistic)
                .WithRequired(e => e.tblUser)
                .WillCascadeOnDelete(false);
        }
    }
}
