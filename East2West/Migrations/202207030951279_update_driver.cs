namespace East2West.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_driver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "HasDriver", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "HasDriver");
        }
    }
}
