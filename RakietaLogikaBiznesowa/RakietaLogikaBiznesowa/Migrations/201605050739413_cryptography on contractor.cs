namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cryptographyoncontractor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contractors", "Owner", c => c.Int());
            AlterColumn("dbo.Contractors", "NIP", c => c.Binary(nullable: false, maxLength: 256, fixedLength: true));
            AlterColumn("dbo.Contractors", "REGON", c => c.Binary(nullable: false, maxLength: 256, fixedLength: true));
            CreateIndex("dbo.Contractors", "Owner");
            AddForeignKey("dbo.Contractors", "Owner", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contractors", "SecondName", c => c.String());
            AddColumn("dbo.Contractors", "FirstName", c => c.String());
            AddColumn("dbo.Contractors", "Pesel", c => c.Long());
            DropForeignKey("dbo.Contractors", "Owner", "dbo.Users");
            DropIndex("dbo.Contractors", new[] { "Owner" });
            AlterColumn("dbo.Contractors", "REGON", c => c.Long(nullable: false));
            AlterColumn("dbo.Contractors", "NIP", c => c.Long(nullable: false));
            DropColumn("dbo.Contractors", "Owner");
        }
    }
}
