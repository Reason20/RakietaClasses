namespace ConsoleApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClearOut : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deals", "CreateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Deals", "CrDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Deals", "CrDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Deals", "CreateDate");
        }
    }
}
