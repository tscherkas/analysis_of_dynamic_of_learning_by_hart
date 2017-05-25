namespace DLH_EF_dataconnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeAnsewer_SurveyToAnswer_Statistic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.tblAnswer",
                c => new
                    {
                        AnswerId = c.Long(nullable: false),
                        AnswerDateTime = c.String(maxLength: 10, fixedLength: true),
                        StimulusId = c.Long(),
                        StatisticId = c.Long(nullable: false),
                        Value = c.String(nullable: false, maxLength: 100, fixedLength: true),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.tblStatistic", t => t.StatisticId)
                .ForeignKey("dbo.tblStimulus", t => t.StimulusId)
                .Index(t => t.StimulusId)
                .Index(t => t.StatisticId);
            
            CreateTable(
                "dbo.tblStatistic",
                c => new
                    {
                        StatisticId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        Date = c.Long(nullable: false),
                        NumberOfCycles = c.Long(nullable: false),
                        Pause = c.Time(nullable: false, precision: 7),
                        Interval = c.Time(nullable: false, precision: 7),
                        DynamicData = c.String(nullable: false, maxLength: 100),
                        tblSurvey_SurveyId = c.Long(),
                    })
                .PrimaryKey(t => t.StatisticId)
                .ForeignKey("dbo.tblUser", t => t.UserId)
                .ForeignKey("dbo.tblSurvey", t => t.tblSurvey_SurveyId)
                .Index(t => t.UserId)
                .Index(t => t.tblSurvey_SurveyId);
            
            CreateTable(
                "dbo.tblUser",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        FirstName = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        Group = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.tblStimulus",
                c => new
                    {
                        StimulusId = c.Long(nullable: false),
                        SurveyId = c.Long(nullable: false),
                        DocumentPath = c.String(nullable: false, maxLength: 1000, fixedLength: true),
                    })
                .PrimaryKey(t => t.StimulusId)
                .ForeignKey("dbo.tblSurvey", t => t.SurveyId)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "dbo.tblSurvey",
                c => new
                    {
                        SurveyId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 1000, fixedLength: true),
                        Description = c.String(nullable: false, maxLength: 1000, fixedLength: true),
                    })
                .PrimaryKey(t => t.SurveyId);
            
            CreateTable(
                "dbo.tblSettings",
                c => new
                    {
                        SettingsId = c.Long(nullable: false),
                        SurveyId = c.Long(nullable: false),
                        Pause = c.Time(precision: 7),
                        Interval = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.SettingsId)
                .ForeignKey("dbo.tblSurvey", t => t.SurveyId)
                .Index(t => t.SurveyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblStimulus", "SurveyId", "dbo.tblSurvey");
            DropForeignKey("dbo.tblStatistic", "tblSurvey_SurveyId", "dbo.tblSurvey");
            DropForeignKey("dbo.tblSettings", "SurveyId", "dbo.tblSurvey");
            DropForeignKey("dbo.tblAnswer", "StimulusId", "dbo.tblStimulus");
            DropForeignKey("dbo.tblStatistic", "UserId", "dbo.tblUser");
            DropForeignKey("dbo.tblAnswer", "StatisticId", "dbo.tblStatistic");
            DropIndex("dbo.tblSettings", new[] { "SurveyId" });
            DropIndex("dbo.tblStimulus", new[] { "SurveyId" });
            DropIndex("dbo.tblStatistic", new[] { "tblSurvey_SurveyId" });
            DropIndex("dbo.tblStatistic", new[] { "UserId" });
            DropIndex("dbo.tblAnswer", new[] { "StatisticId" });
            DropIndex("dbo.tblAnswer", new[] { "StimulusId" });
            DropTable("dbo.tblSettings");
            DropTable("dbo.tblSurvey");
            DropTable("dbo.tblStimulus");
            DropTable("dbo.tblUser");
            DropTable("dbo.tblStatistic");
            DropTable("dbo.tblAnswer");
            DropTable("dbo.sysdiagrams");
        }
    }
}
