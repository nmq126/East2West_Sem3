namespace East2West.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedbagain2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hotels", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Hotels", new[] { "Location_Id" });
            RenameColumn(table: "dbo.Hotels", name: "Location_Id", newName: "LocationId");
            AddColumn("dbo.Flights", "Thumbnail", c => c.String(nullable: false, storeType: "ntext"));
            AddColumn("dbo.Hotels", "Thumbnail", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.Hotels", "LocationId", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Hotels", "LocationId");
            AddForeignKey("dbo.Hotels", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
            DropColumn("dbo.Hotels", "LocaltionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hotels", "LocaltionId", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Hotels", "LocationId", "dbo.Locations");
            DropIndex("dbo.Hotels", new[] { "LocationId" });
            AlterColumn("dbo.Hotels", "LocationId", c => c.String(maxLength: 50));
            DropColumn("dbo.Hotels", "Thumbnail");
            DropColumn("dbo.Flights", "Thumbnail");
            RenameColumn(table: "dbo.Hotels", name: "LocationId", newName: "Location_Id");
            CreateIndex("dbo.Hotels", "Location_Id");
            AddForeignKey("dbo.Hotels", "Location_Id", "dbo.Locations", "Id");
        }
    }
}
