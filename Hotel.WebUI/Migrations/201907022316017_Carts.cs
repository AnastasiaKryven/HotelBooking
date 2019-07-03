namespace Hotel.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Carts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartLineRequests",
                c => new
                    {
                        CartLineRequestId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Request_RequestId = c.Int(),
                    })
                .PrimaryKey(t => t.CartLineRequestId)
                .ForeignKey("dbo.Requests", t => t.Request_RequestId)
                .Index(t => t.Request_RequestId);
            
            CreateTable(
                "dbo.CartLines",
                c => new
                    {
                        CartLineId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Room_RoomId = c.Int(),
                    })
                .PrimaryKey(t => t.CartLineId)
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId)
                .Index(t => t.Room_RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartLines", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.CartLineRequests", "Request_RequestId", "dbo.Requests");
            DropIndex("dbo.CartLines", new[] { "Room_RoomId" });
            DropIndex("dbo.CartLineRequests", new[] { "Request_RequestId" });
            DropTable("dbo.CartLines");
            DropTable("dbo.CartLineRequests");
        }
    }
}
