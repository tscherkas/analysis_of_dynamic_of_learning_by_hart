namespace DLH_EF_dataconnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setUserKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblStatistic", "UserId", "dbo.tblUser");
            DropPrimaryKey("dbo.tblUser");
            AlterColumn("dbo.tblUser", "UserId", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.tblUser", "UserId");
            AddForeignKey("dbo.tblStatistic", "UserId", "dbo.tblUser", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblStatistic", "UserId", "dbo.tblUser");
            DropPrimaryKey("dbo.tblUser");
            AlterColumn("dbo.tblUser", "UserId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.tblUser", "UserId");
            AddForeignKey("dbo.tblStatistic", "UserId", "dbo.tblUser", "UserId");
        }
    }
}
