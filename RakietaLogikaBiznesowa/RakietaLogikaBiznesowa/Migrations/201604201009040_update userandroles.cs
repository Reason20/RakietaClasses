namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateuserandroles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAndRoles", "LastEditTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserAndRoles", "LastEditor", c => c.Int());
            CreateIndex("dbo.UserAndRoles", "LastEditor");
            AddForeignKey("dbo.UserAndRoles", "LastEditor", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAndRoles", "LastEditor", "dbo.Users");
            DropIndex("dbo.UserAndRoles", new[] { "LastEditor" });
            DropColumn("dbo.UserAndRoles", "LastEditor");
            DropColumn("dbo.UserAndRoles", "LastEditTime");
        }
    }
}
