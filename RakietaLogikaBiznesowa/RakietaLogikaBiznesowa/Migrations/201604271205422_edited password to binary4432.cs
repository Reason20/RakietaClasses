namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedpasswordtobinary4432 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.Binary(maxLength: 256, fixedLength: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.Binary(nullable: false, maxLength: 256, fixedLength: true));
        }
    }
}
