namespace DLH_EF_dataconnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addakeytostimulusgrouptable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tblSettings");
            AlterColumn("dbo.tblSettings", "SettingsId", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.tblSettings", "SettingsId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tblSettings");
            AlterColumn("dbo.tblSettings", "SettingsId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.tblSettings", "SettingsId");
        }
    }
}
