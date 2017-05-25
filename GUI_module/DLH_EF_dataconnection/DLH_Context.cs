namespace DLH_EF_dataconnection
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DLH_Context : DbContext
    {
        public DLH_Context()
            : base("name=DLH_Context")
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
                .Property(e => e.Value)
                .IsFixedLength();

            modelBuilder.Entity<tblStimulus>()
                .Property(e => e.DocumentPath)
                .IsFixedLength();

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
                .HasMany(e => e.tblAnswers)
                .WithRequired(e => e.tblStatistic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblSurvey>()
                .HasMany(e => e.tblStimulus)
                .WithRequired(e => e.tblSurvey)
                .WillCascadeOnDelete(false);

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
