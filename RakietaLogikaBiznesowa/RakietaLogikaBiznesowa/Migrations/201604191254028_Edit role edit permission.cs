namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Editroleeditpermission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Permissions", "Name", c => c.String());
            AddColumn("dbo.Roles", "Write", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "Read", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "Update", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "Delete", c => c.Boolean(nullable: false));
            DropColumn("dbo.Permissions", "Function");
            DropColumn("dbo.Permissions", "Write");
            DropColumn("dbo.Permissions", "Read");
            DropColumn("dbo.Permissions", "Update");
            DropColumn("dbo.Permissions", "Delete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Permissions", "Delete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Permissions", "Update", c => c.Boolean(nullable: false));
            AddColumn("dbo.Permissions", "Read", c => c.Boolean(nullable: false));
            AddColumn("dbo.Permissions", "Write", c => c.Boolean(nullable: false));
            AddColumn("dbo.Permissions", "Function", c => c.Int(nullable: false));
            DropColumn("dbo.Roles", "Delete");
            DropColumn("dbo.Roles", "Update");
            DropColumn("dbo.Roles", "Read");
            DropColumn("dbo.Roles", "Write");
            DropColumn("dbo.Permissions", "Name");
        }
    }
}
