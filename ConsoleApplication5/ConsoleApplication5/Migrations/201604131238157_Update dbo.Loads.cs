namespace ConsoleApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedboLoads : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Loads", new[] { "Worker_Id" });
            DropColumn("dbo.Loads", "LastEditor");
            RenameColumn(table: "dbo.MailerSmserSets", name: "Installment_Id", newName: "LoadsId");
            RenameColumn(table: "dbo.Loads", name: "Worker_Id", newName: "LastEditor");
            RenameIndex(table: "dbo.MailerSmserSets", name: "IX_Installment_Id", newName: "IX_LoadsId");
            AddColumn("dbo.Deals", "UserSets_Id", c => c.Int());
            AlterColumn("dbo.Loads", "LastEditor", c => c.Int(nullable: false));
            AlterColumn("dbo.Loads", "LastEditor", c => c.Int(nullable: false));
            CreateIndex("dbo.Loads", "LastEditor");
            CreateIndex("dbo.Deals", "UserSets_Id");
            AddForeignKey("dbo.Deals", "UserSets_Id", "dbo.UserSets", "Id");
            DropColumn("dbo.MailerSmserSets", "VindicationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MailerSmserSets", "VindicationId", c => c.Int());
            DropForeignKey("dbo.Deals", "UserSets_Id", "dbo.UserSets");
            DropIndex("dbo.Deals", new[] { "UserSets_Id" });
            DropIndex("dbo.Loads", new[] { "LastEditor" });
            AlterColumn("dbo.Loads", "LastEditor", c => c.Int());
            AlterColumn("dbo.Loads", "LastEditor", c => c.Int());
            DropColumn("dbo.Deals", "UserSets_Id");
            RenameIndex(table: "dbo.MailerSmserSets", name: "IX_LoadsId", newName: "IX_Installment_Id");
            RenameColumn(table: "dbo.Loads", name: "LastEditor", newName: "Worker_Id");
            RenameColumn(table: "dbo.MailerSmserSets", name: "LoadsId", newName: "Installment_Id");
            AddColumn("dbo.Loads", "LastEditor", c => c.Int());
            CreateIndex("dbo.Loads", "Worker_Id");
        }
    }
}
