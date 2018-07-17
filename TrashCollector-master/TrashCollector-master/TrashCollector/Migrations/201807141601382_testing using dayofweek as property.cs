namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingusingdayofweekasproperty : DbMigration
    {
        public override void Up()
        {

        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "ExtraPickUp", c => c.DateTime());
            AlterColumn("dbo.Customers", "PickUpDay", c => c.DateTime());
        }
    }
}
