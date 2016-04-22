namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cryptoV2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.rsas");
            AlterColumn("dbo.rsas", "publicKey", c => c.String(nullable: false, maxLength: 1000, unicode: false));
            AlterColumn("dbo.rsas", "privateKey", c => c.String(nullable: false, maxLength: 1000, unicode: false));
            AddPrimaryKey("dbo.rsas", new[] { "publicKey", "privateKey" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.rsas");
            AlterColumn("dbo.rsas", "privateKey", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.rsas", "publicKey", c => c.String(nullable: false, maxLength: 500));
            AddPrimaryKey("dbo.rsas", new[] { "publicKey", "privateKey" });
        }
    }
}
