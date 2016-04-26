namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aes2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AesUserKeys");
            AlterColumn("dbo.AesUserKeys", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.AesUserKeys", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AesUserKeys");
            AlterColumn("dbo.AesUserKeys", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.AesUserKeys", "Id");
        }
    }
}
