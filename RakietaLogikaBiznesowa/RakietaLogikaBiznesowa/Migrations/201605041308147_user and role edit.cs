namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userandroleedit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAndRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserAndRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAndRoles", "LastEditor", "dbo.Users");
            DropIndex("dbo.UserAndRoles", new[] { "UserId" });
            DropIndex("dbo.UserAndRoles", new[] { "RoleId" });
            DropIndex("dbo.UserAndRoles", new[] { "LastEditor" });
            CreateTable(
                "dbo.UsersRoles",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.User_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
            DropTable("dbo.UserAndRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserAndRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        LastEditor = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.UsersRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UsersRoles", "Role_Id", "dbo.Roles");
            DropIndex("dbo.UsersRoles", new[] { "User_Id" });
            DropIndex("dbo.UsersRoles", new[] { "Role_Id" });
            DropTable("dbo.UsersRoles");
            CreateIndex("dbo.UserAndRoles", "LastEditor");
            CreateIndex("dbo.UserAndRoles", "RoleId");
            CreateIndex("dbo.UserAndRoles", "UserId");
            AddForeignKey("dbo.UserAndRoles", "LastEditor", "dbo.Users", "Id");
            AddForeignKey("dbo.UserAndRoles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserAndRoles", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
    }
}
