namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repairfactures : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Factures", "UserId", c => c.Int());
            CreateIndex("dbo.Factures", "UserId");
            AddForeignKey("dbo.Factures", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factures", "UserId", "dbo.Users");
            DropIndex("dbo.Factures", new[] { "UserId" });
            DropColumn("dbo.Factures", "UserId");
        }
    }
}
