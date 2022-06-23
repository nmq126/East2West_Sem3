namespace East2West.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarModels", "Name", c => c.String(nullable: false, storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CarModels", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
