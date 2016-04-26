namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aes23 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AesUserKeys");
            AddColumn("dbo.AesUserKeys", "PESEL", c => c.Long(nullable: false));
            AlterColumn("dbo.AesUserKeys", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.AesUserKeys", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AesUserKeys");
            AlterColumn("dbo.AesUserKeys", "Id", c => c.Long(nullable: false, identity: true));
            DropColumn("dbo.AesUserKeys", "PESEL");
            AddPrimaryKey("dbo.AesUserKeys", "Id");
        }
    }
}
