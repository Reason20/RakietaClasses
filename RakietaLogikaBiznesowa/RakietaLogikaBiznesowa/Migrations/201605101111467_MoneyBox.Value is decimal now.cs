namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoneyBoxValueisdecimalnow : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Moneybox", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Moneybox", "Value", c => c.String(nullable: false));
        }
    }
}
