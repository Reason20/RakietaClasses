namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AesUserKeys");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AesUserKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pesel = c.Long(),
                        IV = c.String(maxLength: 5000, unicode: false),
                        key = c.String(maxLength: 5000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
