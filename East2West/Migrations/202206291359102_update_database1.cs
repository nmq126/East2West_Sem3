namespace East2West.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "RefundId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "RefundId", c => c.String(maxLength: 50));
        }
    }
}
