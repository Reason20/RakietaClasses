namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cryptoV4FINAL : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.rsas");
            AddColumn("dbo.rsas", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.rsas", "publicKey", c => c.String(maxLength: 5000, unicode: false));
            AlterColumn("dbo.rsas", "privateKey", c => c.String(maxLength: 5000, unicode: false));
            AddPrimaryKey("dbo.rsas", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.rsas");
            AlterColumn("dbo.rsas", "privateKey", c => c.String(nullable: false, maxLength: 5000, unicode: false));
            AlterColumn("dbo.rsas", "publicKey", c => c.String(nullable: false, maxLength: 5000, unicode: false));
            DropColumn("dbo.rsas", "Id");
            AddPrimaryKey("dbo.rsas", new[] { "publicKey", "privateKey" });
        }
    }
}
