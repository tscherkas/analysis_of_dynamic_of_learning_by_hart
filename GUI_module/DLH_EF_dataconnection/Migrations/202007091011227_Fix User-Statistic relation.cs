namespace DLH_EF_dataconnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixUserStatisticrelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Statistics", "UserId", "dbo.Users");
            DropIndex("dbo.Statistics", new[] { "UserId" });
            RenameColumn(table: "dbo.Statistics", name: "UserId", newName: "User_UserId");
            AlterColumn("dbo.Statistics", "User_UserId", c => c.Long());
            CreateIndex("dbo.Statistics", "User_UserId");
            AddForeignKey("dbo.Statistics", "User_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Statistics", "User_UserId", "dbo.Users");
            DropIndex("dbo.Statistics", new[] { "User_UserId" });
            AlterColumn("dbo.Statistics", "User_UserId", c => c.Long(nullable: false));
            RenameColumn(table: "dbo.Statistics", name: "User_UserId", newName: "UserId");
            CreateIndex("dbo.Statistics", "UserId");
            AddForeignKey("dbo.Statistics", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
