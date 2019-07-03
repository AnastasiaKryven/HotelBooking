namespace Hotel.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToRequest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "User_Id", "dbo.Users");
            DropIndex("dbo.Requests", new[] { "User_Id" });
            CreateTable(
                "dbo.RequestUsers",
                c => new
                    {
                        Request_RequestId = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Request_RequestId, t.User_Id })
                .ForeignKey("dbo.Requests", t => t.Request_RequestId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Request_RequestId)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Requests", "UserId", c => c.Int());
            DropColumn("dbo.Requests", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "User_Id", c => c.Int());
            DropForeignKey("dbo.RequestUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RequestUsers", "Request_RequestId", "dbo.Requests");
            DropIndex("dbo.RequestUsers", new[] { "User_Id" });
            DropIndex("dbo.RequestUsers", new[] { "Request_RequestId" });
            DropColumn("dbo.Requests", "UserId");
            DropTable("dbo.RequestUsers");
            CreateIndex("dbo.Requests", "User_Id");
            AddForeignKey("dbo.Requests", "User_Id", "dbo.Users", "Id");
        }
    }
}
