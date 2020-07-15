namespace DLH_EF_dataconnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Long(nullable: false, identity: true),
                        AnswerDateTime = c.DateTime(nullable: false),
                        StimulusId = c.Long(),
                        StatisticId = c.Long(),
                        Value = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Statistics", t => t.StatisticId)
                .ForeignKey("dbo.Stimuli", t => t.StimulusId)
                .Index(t => t.StimulusId)
                .Index(t => t.StatisticId);
            
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        StatisticId = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        SurveyId = c.Long(nullable: false),
                        Date = c.DateTime(nullable: false),
                        NumberOfCycles = c.Long(nullable: false),
                        DynamicData = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.StatisticId)
                .ForeignKey("dbo.Surveys", t => t.SurveyId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        SurveyId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 1000),
                        Description = c.String(nullable: false, maxLength: 1000),
                        StimulusGroup_Id = c.Long(),
                    })
                .PrimaryKey(t => t.SurveyId)
                .ForeignKey("dbo.StimulusGroups", t => t.StimulusGroup_Id)
                .Index(t => t.StimulusGroup_Id);
            
            CreateTable(
                "dbo.StimulusGroups",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        Group = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Stimuli",
                c => new
                    {
                        StimulusId = c.Long(nullable: false, identity: true),
                        DocumentPath = c.String(nullable: false, maxLength: 1000),
                        Value = c.String(nullable: false, maxLength: 1000),
                        StimulusGroup_Id = c.Long(),
                    })
                .PrimaryKey(t => t.StimulusId)
                .ForeignKey("dbo.StimulusGroups", t => t.StimulusGroup_Id)
                .Index(t => t.StimulusGroup_Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        SettingsId = c.Long(nullable: false, identity: true),
                        SurveyId = c.Long(nullable: false),
                        Pause = c.Time(precision: 7),
                        Interval = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.SettingsId)
                .ForeignKey("dbo.Surveys", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.SurveyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Settings", "SurveyId", "dbo.Surveys");
            DropForeignKey("dbo.Answers", "StimulusId", "dbo.Stimuli");
            DropForeignKey("dbo.Stimuli", "StimulusGroup_Id", "dbo.StimulusGroups");
            DropForeignKey("dbo.Answers", "StatisticId", "dbo.Statistics");
            DropForeignKey("dbo.Statistics", "UserId", "dbo.Users");
            DropForeignKey("dbo.Statistics", "SurveyId", "dbo.Surveys");
            DropForeignKey("dbo.Surveys", "StimulusGroup_Id", "dbo.StimulusGroups");
            DropIndex("dbo.Settings", new[] { "SurveyId" });
            DropIndex("dbo.Stimuli", new[] { "StimulusGroup_Id" });
            DropIndex("dbo.Surveys", new[] { "StimulusGroup_Id" });
            DropIndex("dbo.Statistics", new[] { "SurveyId" });
            DropIndex("dbo.Statistics", new[] { "UserId" });
            DropIndex("dbo.Answers", new[] { "StatisticId" });
            DropIndex("dbo.Answers", new[] { "StimulusId" });
            DropTable("dbo.Settings");
            DropTable("dbo.Stimuli");
            DropTable("dbo.Users");
            DropTable("dbo.StimulusGroups");
            DropTable("dbo.Surveys");
            DropTable("dbo.Statistics");
            DropTable("dbo.Answers");
        }
    }
}
