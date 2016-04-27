namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aes231 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AesUserKeys", "PESEL", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AesUserKeys", "PESEL", c => c.Long(nullable: false));
        }
    }
}
