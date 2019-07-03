namespace Hotel.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migra : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "DateStart");
            DropColumn("dbo.Rooms", "DateEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "DateEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rooms", "DateStart", c => c.DateTime(nullable: false));
        }
    }
}
