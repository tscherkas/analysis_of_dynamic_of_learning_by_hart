namespace DLH_EF_dataconnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSurveylinkinAnswers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblSettings", "SurveyId", "dbo.tblSurvey");
            DropForeignKey("dbo.tblAnswer", "StatisticId", "dbo.tblStatistic");
            DropForeignKey("dbo.tblAnswer", "StimulusId", "dbo.tblStimulus");
            DropIndex("dbo.tblAnswer", new[] { "StatisticId" });
            DropPrimaryKey("dbo.tblAnswer");
            DropPrimaryKey("dbo.tblStatistic");
            DropPrimaryKey("dbo.tblStimulus");
            DropPrimaryKey("dbo.tblSurvey");
            AddColumn("dbo.tblStatistic", "SurveyId", c => c.Long(nullable: false));
            AlterColumn("dbo.tblAnswer", "AnswerId", c => c.Long(nullable: false));
            AlterColumn("dbo.tblAnswer", "AnswerDateTime", c => c.String(maxLength: 10));
            AlterColumn("dbo.tblAnswer", "StatisticId", c => c.Long());
            AlterColumn("dbo.tblAnswer", "Value", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.tblStatistic", "StatisticId", c => c.Long(nullable: false));
            AlterColumn("dbo.tblStatistic", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tblStimulus", "StimulusId", c => c.Long(nullable: false));
            AlterColumn("dbo.tblStimulus", "DocumentPath", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.tblSurvey", "SurveyId", c => c.Long(nullable: false));
            AlterColumn("dbo.tblSurvey", "Name", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.tblSurvey", "Description", c => c.String(nullable: false, maxLength: 1000));
            AddPrimaryKey("dbo.tblAnswer", "AnswerId");
            AddPrimaryKey("dbo.tblStatistic", "StatisticId");
            AddPrimaryKey("dbo.tblStimulus", "StimulusId");
            AddPrimaryKey("dbo.tblSurvey", "SurveyId");
            CreateIndex("dbo.tblAnswer", "StatisticId");
            CreateIndex("dbo.tblStatistic", "SurveyId");
            AddForeignKey("dbo.tblStatistic", "SurveyId", "dbo.tblSurvey", "SurveyId", cascadeDelete: true);
            AddForeignKey("dbo.tblSettings", "SurveyId", "dbo.tblSurvey", "SurveyId", cascadeDelete: true);
            AddForeignKey("dbo.tblAnswer", "StatisticId", "dbo.tblStatistic", "StatisticId");
            AddForeignKey("dbo.tblAnswer", "StimulusId", "dbo.tblStimulus", "StimulusId");
            DropColumn("dbo.tblStatistic", "Pause");
            DropColumn("dbo.tblStatistic", "Interval");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblStatistic", "Interval", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.tblStatistic", "Pause", c => c.Time(nullable: false, precision: 7));
            DropForeignKey("dbo.tblAnswer", "StimulusId", "dbo.tblStimulus");
            DropForeignKey("dbo.tblAnswer", "StatisticId", "dbo.tblStatistic");
            DropForeignKey("dbo.tblSettings", "SurveyId", "dbo.tblSurvey");
            DropForeignKey("dbo.tblStatistic", "SurveyId", "dbo.tblSurvey");
            DropIndex("dbo.tblStatistic", new[] { "SurveyId" });
            DropIndex("dbo.tblAnswer", new[] { "StatisticId" });
            DropPrimaryKey("dbo.tblSurvey");
            DropPrimaryKey("dbo.tblStimulus");
            DropPrimaryKey("dbo.tblStatistic");
            DropPrimaryKey("dbo.tblAnswer");
            AlterColumn("dbo.tblSurvey", "Description", c => c.String(nullable: false, maxLength: 1000, fixedLength: true));
            AlterColumn("dbo.tblSurvey", "Name", c => c.String(nullable: false, maxLength: 1000, fixedLength: true));
            AlterColumn("dbo.tblSurvey", "SurveyId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.tblStimulus", "DocumentPath", c => c.String(nullable: false, maxLength: 1000, fixedLength: true));
            AlterColumn("dbo.tblStimulus", "StimulusId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.tblStatistic", "Date", c => c.Long(nullable: false));
            AlterColumn("dbo.tblStatistic", "StatisticId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.tblAnswer", "Value", c => c.String(nullable: false, maxLength: 100, fixedLength: true));
            AlterColumn("dbo.tblAnswer", "StatisticId", c => c.Long(nullable: false));
            AlterColumn("dbo.tblAnswer", "AnswerDateTime", c => c.String(maxLength: 10, fixedLength: true));
            AlterColumn("dbo.tblAnswer", "AnswerId", c => c.Long(nullable: false, identity: true));
            DropColumn("dbo.tblStatistic", "SurveyId");
            AddPrimaryKey("dbo.tblSurvey", "SurveyId");
            AddPrimaryKey("dbo.tblStimulus", "StimulusId");
            AddPrimaryKey("dbo.tblStatistic", "StatisticId");
            AddPrimaryKey("dbo.tblAnswer", "AnswerId");
            CreateIndex("dbo.tblAnswer", "StatisticId");
            AddForeignKey("dbo.tblAnswer", "StimulusId", "dbo.tblStimulus", "StimulusId");
            AddForeignKey("dbo.tblAnswer", "StatisticId", "dbo.tblStatistic", "StatisticId");
            AddForeignKey("dbo.tblSettings", "SurveyId", "dbo.tblSurvey", "SurveyId");
        }
    }
}
