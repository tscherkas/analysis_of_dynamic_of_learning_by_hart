namespace DLH_EF_dataconnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixStimulusfields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stimuli", "StimulusGroup_Id", "dbo.StimulusGroups");
            DropIndex("dbo.Stimuli", new[] { "StimulusGroup_Id" });
            RenameColumn(table: "dbo.Stimuli", name: "StimulusGroup_Id", newName: "StimulusGroupId");
            AlterColumn("dbo.Stimuli", "StimulusGroupId", c => c.Long(nullable: false));
            CreateIndex("dbo.Stimuli", "StimulusGroupId");
            AddForeignKey("dbo.Stimuli", "StimulusGroupId", "dbo.StimulusGroups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stimuli", "StimulusGroupId", "dbo.StimulusGroups");
            DropIndex("dbo.Stimuli", new[] { "StimulusGroupId" });
            AlterColumn("dbo.Stimuli", "StimulusGroupId", c => c.Long());
            RenameColumn(table: "dbo.Stimuli", name: "StimulusGroupId", newName: "StimulusGroup_Id");
            CreateIndex("dbo.Stimuli", "StimulusGroup_Id");
            AddForeignKey("dbo.Stimuli", "StimulusGroup_Id", "dbo.StimulusGroups", "Id");
        }
    }
}
