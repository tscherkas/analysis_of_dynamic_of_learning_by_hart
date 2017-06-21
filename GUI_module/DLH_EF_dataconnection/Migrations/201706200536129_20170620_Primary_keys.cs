namespace DLH_EF_dataconnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170620_Primary_keys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblAnswer", "StatisticId", "dbo.tblStatistic");
            DropForeignKey("dbo.tblStatistic", "UserId", "dbo.tblUser");
            DropForeignKey("dbo.tblAnswer", "StimulusId", "dbo.tblStimulus");
            DropForeignKey("dbo.tblSettings", "SurveyId", "dbo.tblSurvey");
            DropForeignKey("dbo.tblStimulus", "SurveyId", "dbo.tblSurvey");
            DropPrimaryKey("dbo.tblAnswer");
            DropPrimaryKey("dbo.tblStatistic");
            DropPrimaryKey("dbo.tblUser");
            DropPrimaryKey("dbo.tblStimulus");
            DropPrimaryKey("dbo.tblSurvey");
            AlterColumn("dbo.tblAnswer", "AnswerId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.tblStatistic", "StatisticId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.tblUser", "UserId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.tblStimulus", "StimulusId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.tblSurvey", "SurveyId", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.tblAnswer", "AnswerId");
            AddPrimaryKey("dbo.tblStatistic", "StatisticId");
            AddPrimaryKey("dbo.tblUser", "UserId");
            AddPrimaryKey("dbo.tblStimulus", "StimulusId");
            AddPrimaryKey("dbo.tblSurvey", "SurveyId");
            AddForeignKey("dbo.tblAnswer", "StatisticId", "dbo.tblStatistic", "StatisticId");
            AddForeignKey("dbo.tblStatistic", "UserId", "dbo.tblUser", "UserId");
            AddForeignKey("dbo.tblAnswer", "StimulusId", "dbo.tblStimulus", "StimulusId");
            AddForeignKey("dbo.tblSettings", "SurveyId", "dbo.tblSurvey", "SurveyId");
            AddForeignKey("dbo.tblStimulus", "SurveyId", "dbo.tblSurvey", "SurveyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblStimulus", "SurveyId", "dbo.tblSurvey");
            DropForeignKey("dbo.tblSettings", "SurveyId", "dbo.tblSurvey");
            DropForeignKey("dbo.tblAnswer", "StimulusId", "dbo.tblStimulus");
            DropForeignKey("dbo.tblStatistic", "UserId", "dbo.tblUser");
            DropForeignKey("dbo.tblAnswer", "StatisticId", "dbo.tblStatistic");
            DropPrimaryKey("dbo.tblSurvey");
            DropPrimaryKey("dbo.tblStimulus");
            DropPrimaryKey("dbo.tblUser");
            DropPrimaryKey("dbo.tblStatistic");
            DropPrimaryKey("dbo.tblAnswer");
            AlterColumn("dbo.tblSurvey", "SurveyId", c => c.Long(nullable: false));
            AlterColumn("dbo.tblStimulus", "StimulusId", c => c.Long(nullable: false));
            AlterColumn("dbo.tblUser", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.tblStatistic", "StatisticId", c => c.Long(nullable: false));
            AlterColumn("dbo.tblAnswer", "AnswerId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.tblSurvey", "SurveyId");
            AddPrimaryKey("dbo.tblStimulus", "StimulusId");
            AddPrimaryKey("dbo.tblUser", "UserId");
            AddPrimaryKey("dbo.tblStatistic", "StatisticId");
            AddPrimaryKey("dbo.tblAnswer", "AnswerId");
            AddForeignKey("dbo.tblStimulus", "SurveyId", "dbo.tblSurvey", "SurveyId");
            AddForeignKey("dbo.tblSettings", "SurveyId", "dbo.tblSurvey", "SurveyId");
            AddForeignKey("dbo.tblAnswer", "StimulusId", "dbo.tblStimulus", "StimulusId");
            AddForeignKey("dbo.tblStatistic", "UserId", "dbo.tblUser", "UserId");
            AddForeignKey("dbo.tblAnswer", "StatisticId", "dbo.tblStatistic", "StatisticId");
        }
    }
}
