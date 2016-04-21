namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastEditor : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Roles", new[] { "LastEditor" });
            AlterColumn("dbo.Roles", "LastEditor", c => c.Int());
            CreateIndex("dbo.Roles", "LastEditor");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Roles", new[] { "LastEditor" });
            AlterColumn("dbo.Roles", "LastEditor", c => c.Int(nullable: false));
            CreateIndex("dbo.Roles", "LastEditor");
        }
    }
}
