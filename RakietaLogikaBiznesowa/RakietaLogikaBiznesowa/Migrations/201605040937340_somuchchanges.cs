namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somuchchanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.Binary(nullable: false, maxLength: 256, fixedLength: true));
            AlterColumn("dbo.Users", "PESEL", c => c.Binary(nullable: false, maxLength: 256, fixedLength: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PESEL", c => c.Binary(maxLength: 256, fixedLength: true));
            AlterColumn("dbo.Users", "Password", c => c.Binary(maxLength: 256, fixedLength: true));
        }
    }
}
