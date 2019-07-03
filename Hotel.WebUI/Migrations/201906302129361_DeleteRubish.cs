namespace Hotel.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteRubish : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "DateRentStart");
            DropColumn("dbo.Rooms", "DateRentEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "DateRentEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rooms", "DateRentStart", c => c.DateTime(nullable: false));
        }
    }
}
