namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemanytomany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.UsersRoles", "User_Id", "dbo.Users");
            DropIndex("dbo.UsersRoles", new[] { "Role_Id" });
            DropIndex("dbo.UsersRoles", new[] { "User_Id" });
            CreateTable(
                "dbo.UserAndRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            DropTable("dbo.UsersRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsersRoles",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.User_Id });
            
            DropForeignKey("dbo.UserAndRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAndRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.UserAndRoles", new[] { "RoleId" });
            DropIndex("dbo.UserAndRoles", new[] { "UserId" });
            DropTable("dbo.UserAndRoles");
            CreateIndex("dbo.UsersRoles", "User_Id");
            CreateIndex("dbo.UsersRoles", "Role_Id");
            AddForeignKey("dbo.UsersRoles", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsersRoles", "Role_Id", "dbo.Roles", "Id", cascadeDelete: true);
        }
    }
}
