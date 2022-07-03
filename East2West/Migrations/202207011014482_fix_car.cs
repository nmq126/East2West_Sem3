namespace East2West.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix_car : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Description", c => c.String(nullable: false, storeType: "ntext"));
            AddColumn("dbo.Cars", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Rating");
            DropColumn("dbo.Cars", "Description");
        }
    }
}
