namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixesinLoads : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loads", "IsPaid", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Loads", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Loads", "Value", c => c.Double(nullable: false));
            DropColumn("dbo.Loads", "IsPaid");
        }
    }
}
