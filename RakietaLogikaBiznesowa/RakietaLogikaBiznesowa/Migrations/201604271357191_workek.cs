namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workek : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsWorker", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "WorkerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "WorkerId", c => c.Int());
            DropColumn("dbo.Users", "IsWorker");
        }
    }
}
