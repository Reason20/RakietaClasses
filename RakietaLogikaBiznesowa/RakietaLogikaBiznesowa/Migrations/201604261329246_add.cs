namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AesUserKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pesel = c.Long(nullable: false),
                        Key = c.String(),
                        IV = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AesUserKeys");
        }
    }
}
