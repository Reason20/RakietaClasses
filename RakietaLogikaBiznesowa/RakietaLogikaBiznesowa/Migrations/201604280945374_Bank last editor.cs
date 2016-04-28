namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Banklasteditor : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BankAccounts", new[] { "LastEditor" });
            AlterColumn("dbo.BankAccounts", "LastEditor", c => c.Int());
            AlterColumn("dbo.Factures", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.BankAccounts", "LastEditor");
        }
        
        public override void Down()
        {
            DropIndex("dbo.BankAccounts", new[] { "LastEditor" });
            AlterColumn("dbo.Factures", "Value", c => c.Double(nullable: false));
            AlterColumn("dbo.BankAccounts", "LastEditor", c => c.Int(nullable: false));
            CreateIndex("dbo.BankAccounts", "LastEditor");
        }
    }
}
