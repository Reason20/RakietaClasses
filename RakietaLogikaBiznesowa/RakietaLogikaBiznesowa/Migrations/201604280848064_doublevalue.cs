namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doublevalue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Factures", "Value", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Factures", "Value", c => c.Int(nullable: false));
        }
    }
}
