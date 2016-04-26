namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AesUserKeys",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IV = c.String(maxLength: 5000, unicode: false),
                        key = c.String(maxLength: 5000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AesUserKeys");
        }
    }
}
