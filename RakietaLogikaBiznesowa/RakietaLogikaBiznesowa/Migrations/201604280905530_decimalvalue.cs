namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decimalvalue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Factures", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Factures", "Value", c => c.Double(nullable: false));
        }
    }
}
