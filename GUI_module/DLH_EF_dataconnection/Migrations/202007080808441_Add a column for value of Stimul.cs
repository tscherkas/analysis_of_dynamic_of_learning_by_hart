namespace DLH_EF_dataconnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddacolumnforvalueofStimul : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblStimulus", "Value", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.tblAnswer", "AnswerDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblAnswer", "AnswerDateTime", c => c.String(maxLength: 10));
            DropColumn("dbo.tblStimulus", "Value");
        }
    }
}
