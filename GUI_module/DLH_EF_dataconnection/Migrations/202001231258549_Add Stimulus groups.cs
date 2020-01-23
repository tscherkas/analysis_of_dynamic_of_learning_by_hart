namespace DLH_EF_dataconnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStimulusgroups : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblStimulus", "SurveyId", "dbo.tblSurvey");
            DropIndex("dbo.tblStimulus", new[] { "SurveyId" });
            CreateTable(
                "dbo.tblStimulusGroup",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tblStimulus", "tblStimulusGroup_Id", c => c.Long());
            AddColumn("dbo.tblSurvey", "StimulusGroup_Id", c => c.Long());
            CreateIndex("dbo.tblStimulus", "tblStimulusGroup_Id");
            CreateIndex("dbo.tblSurvey", "StimulusGroup_Id");
            AddForeignKey("dbo.tblStimulus", "tblStimulusGroup_Id", "dbo.tblStimulusGroup", "Id");
            AddForeignKey("dbo.tblSurvey", "StimulusGroup_Id", "dbo.tblStimulusGroup", "Id");
            DropColumn("dbo.tblStimulus", "SurveyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblStimulus", "SurveyId", c => c.Long(nullable: false));
            DropForeignKey("dbo.tblSurvey", "StimulusGroup_Id", "dbo.tblStimulusGroup");
            DropForeignKey("dbo.tblStimulus", "tblStimulusGroup_Id", "dbo.tblStimulusGroup");
            DropIndex("dbo.tblSurvey", new[] { "StimulusGroup_Id" });
            DropIndex("dbo.tblStimulus", new[] { "tblStimulusGroup_Id" });
            DropColumn("dbo.tblSurvey", "StimulusGroup_Id");
            DropColumn("dbo.tblStimulus", "tblStimulusGroup_Id");
            DropTable("dbo.tblStimulusGroup");
            CreateIndex("dbo.tblStimulus", "SurveyId");
            AddForeignKey("dbo.tblStimulus", "SurveyId", "dbo.tblSurvey", "SurveyId");
        }
    }
}
