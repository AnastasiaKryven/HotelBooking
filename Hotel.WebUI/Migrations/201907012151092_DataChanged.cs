namespace Hotel.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "RoomId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "RoomId");
        }
    }
}
