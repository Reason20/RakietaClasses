namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedpasswordtobinary4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.Binary(nullable: false, maxLength: 256, fixedLength: true));
            DropTable("dbo.AesUserKeys");
        }
        
        public override void Down()
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
            
            AlterColumn("dbo.Users", "Password", c => c.Binary(maxLength: 256, fixedLength: true));
        }
    }
}
