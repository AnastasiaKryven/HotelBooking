namespace Hotel.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserBookings",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Booking_BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Booking_BookingId })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bookings", t => t.Booking_BookingId, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Booking_BookingId);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.User_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Checks", "UserId", c => c.Int());
            AddColumn("dbo.Requests", "User_Id", c => c.Int());
            CreateIndex("dbo.Checks", "UserId");
            CreateIndex("dbo.Requests", "User_Id");
            AddForeignKey("dbo.Checks", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Requests", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Checks", "IdClient");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Checks", "IdClient", c => c.Int());
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Requests", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Checks", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserBookings", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.UserBookings", "User_Id", "dbo.Users");
            DropIndex("dbo.RoleUsers", new[] { "User_Id" });
            DropIndex("dbo.RoleUsers", new[] { "Role_Id" });
            DropIndex("dbo.UserBookings", new[] { "Booking_BookingId" });
            DropIndex("dbo.UserBookings", new[] { "User_Id" });
            DropIndex("dbo.Requests", new[] { "User_Id" });
            DropIndex("dbo.Checks", new[] { "UserId" });
            DropColumn("dbo.Requests", "User_Id");
            DropColumn("dbo.Checks", "UserId");
            DropTable("dbo.RoleUsers");
            DropTable("dbo.UserBookings");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
        }
    }
}
