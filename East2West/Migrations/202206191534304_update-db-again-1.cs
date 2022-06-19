namespace East2West.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedbagain1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hotels", "Name", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.Tours", "Duration", c => c.Int(nullable: false));
            AlterColumn("dbo.TourSchedules", "Name", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TourSchedules", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tours", "Duration", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Hotels", "Name");
        }
    }
}
