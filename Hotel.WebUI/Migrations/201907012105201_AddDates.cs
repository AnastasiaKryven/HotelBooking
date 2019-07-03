namespace Hotel.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "DateStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rooms", "DateEnd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "DateEnd");
            DropColumn("dbo.Rooms", "DateStart");
        }
    }
}
