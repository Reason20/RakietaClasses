namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bankaccountedit : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BankAccounts", name: "AddressId", newName: "Address_Id");
            RenameIndex(table: "dbo.BankAccounts", name: "IX_AddressId", newName: "IX_Address_Id");
            AlterColumn("dbo.BankAccounts", "BankAccountNumber", c => c.String());
            AlterColumn("dbo.BankAccounts", "BankName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BankAccounts", "BankName", c => c.String(nullable: false));
            AlterColumn("dbo.BankAccounts", "BankAccountNumber", c => c.String(nullable: false));
            RenameIndex(table: "dbo.BankAccounts", name: "IX_Address_Id", newName: "IX_AddressId");
            RenameColumn(table: "dbo.BankAccounts", name: "Address_Id", newName: "AddressId");
        }
    }
}
