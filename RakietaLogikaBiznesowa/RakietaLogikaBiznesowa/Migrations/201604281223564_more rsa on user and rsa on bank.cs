namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class morersaonuserandrsaonbank : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BankAccounts", "BankAccountNumber", c => c.Binary(maxLength: 256, fixedLength: true));
            AlterColumn("dbo.BankAccounts", "CardNumber", c => c.Binary(maxLength: 256, fixedLength: true));
            AlterColumn("dbo.Users", "PESEL", c => c.Binary(maxLength: 256, fixedLength: true));
            AlterColumn("dbo.Users", "IDNumber", c => c.Binary(nullable: false, maxLength: 256, fixedLength: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "IDNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "PESEL", c => c.Long(nullable: false));
            AlterColumn("dbo.BankAccounts", "CardNumber", c => c.String());
            AlterColumn("dbo.BankAccounts", "BankAccountNumber", c => c.String());
        }
    }
}
