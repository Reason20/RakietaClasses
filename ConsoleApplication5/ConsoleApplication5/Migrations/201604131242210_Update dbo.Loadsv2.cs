namespace ConsoleApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedboLoadsv2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Deals", name: "DealMenagerId", newName: "MenagerId");
            RenameIndex(table: "dbo.Deals", name: "IX_DealMenagerId", newName: "IX_MenagerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Deals", name: "IX_MenagerId", newName: "IX_DealMenagerId");
            RenameColumn(table: "dbo.Deals", name: "MenagerId", newName: "DealMenagerId");
        }
    }
}
