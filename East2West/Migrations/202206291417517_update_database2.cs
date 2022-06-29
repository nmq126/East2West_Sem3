namespace East2West.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TourDetails", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TourDetails", "Status");
        }
    }
}
