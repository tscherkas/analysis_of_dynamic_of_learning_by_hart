namespace DLH_EF_dataconnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeAnsewer_SurveyToAnswer_Statistic_p2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblStatistic", "tblSurvey_SurveyId", "dbo.tblSurvey");
            DropIndex("dbo.tblStatistic", new[] { "tblSurvey_SurveyId" });
            DropColumn("dbo.tblStatistic", "tblSurvey_SurveyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblStatistic", "tblSurvey_SurveyId", c => c.Long());
            CreateIndex("dbo.tblStatistic", "tblSurvey_SurveyId");
            AddForeignKey("dbo.tblStatistic", "tblSurvey_SurveyId", "dbo.tblSurvey", "SurveyId");
        }
    }
}
