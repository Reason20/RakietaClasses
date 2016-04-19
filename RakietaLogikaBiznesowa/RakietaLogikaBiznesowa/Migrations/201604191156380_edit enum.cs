namespace RakietaLogikaBiznesowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editenum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payoff", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Discounts", "LastEditTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Discounts", "LastEditTime", c => c.String(nullable: false));
            DropColumn("dbo.Payoff", "Date");
        }
    }
}
