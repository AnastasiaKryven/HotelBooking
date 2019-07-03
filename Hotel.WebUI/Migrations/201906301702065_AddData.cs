namespace Hotel.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        DateEntry = c.DateTime(nullable: false),
                        DateExit = c.DateTime(nullable: false),
                        RoomId = c.Int(),
                    })
                .PrimaryKey(t => t.BookingId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        CountOfPeople = c.Int(nullable: false),
                        RoomClass = c.Int(nullable: false),
                        RoomState = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                        DateRentStart = c.DateTime(nullable: false),
                        DateRentEnd = c.DateTime(nullable: false),
                        Booking_BookingId = c.Int(),
                        Check_CheckId = c.Int(),
                        Request_RequestId = c.Int(),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Bookings", t => t.Booking_BookingId)
                .ForeignKey("dbo.Checks", t => t.Check_CheckId)
                .ForeignKey("dbo.Requests", t => t.Request_RequestId)
                .Index(t => t.Booking_BookingId)
                .Index(t => t.Check_CheckId)
                .Index(t => t.Request_RequestId);
            
            CreateTable(
                "dbo.Checks",
                c => new
                    {
                        CheckId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        IdClient = c.Int(),
                        IdRoom = c.Int(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CheckId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        DateEntry = c.DateTime(nullable: false),
                        DateExit = c.DateTime(nullable: false),
                        CountOfPlace = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        TextOfReview = c.String(),
                        Date = c.DateTime(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ReviewId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "Request_RequestId", "dbo.Requests");
            DropForeignKey("dbo.Rooms", "Check_CheckId", "dbo.Checks");
            DropForeignKey("dbo.Rooms", "Booking_BookingId", "dbo.Bookings");
            DropIndex("dbo.Rooms", new[] { "Request_RequestId" });
            DropIndex("dbo.Rooms", new[] { "Check_CheckId" });
            DropIndex("dbo.Rooms", new[] { "Booking_BookingId" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Requests");
            DropTable("dbo.Checks");
            DropTable("dbo.Rooms");
            DropTable("dbo.Bookings");
        }
    }
}
