namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FactureUpdate : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Factures", new[] { "UpdateUserId" });
            RenameColumn(table: "dbo.Factures", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Factures", name: "UpdateUserId", newName: "User_Id1");
            RenameIndex(table: "dbo.Factures", name: "IX_UserId", newName: "IX_User_Id");
            AlterColumn("dbo.Factures", "User_Id1", c => c.Int());
            CreateIndex("dbo.Factures", "User_Id1");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Factures", new[] { "User_Id1" });
            AlterColumn("dbo.Factures", "User_Id1", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Factures", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.Factures", name: "User_Id1", newName: "UpdateUserId");
            RenameColumn(table: "dbo.Factures", name: "User_Id", newName: "UserId");
            CreateIndex("dbo.Factures", "UpdateUserId");
        }
    }
}
