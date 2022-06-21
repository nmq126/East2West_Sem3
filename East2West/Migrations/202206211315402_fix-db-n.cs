namespace East2West.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdbn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hotels", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hotels", "Price", c => c.String(nullable: false));
        }
    }
}
