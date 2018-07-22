namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedboolconfirmedPickUptocustomermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ConfirmedPickUp", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ConfirmedPickUp");
        }
    }
}
