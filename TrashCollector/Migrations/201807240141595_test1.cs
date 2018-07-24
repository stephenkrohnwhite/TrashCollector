namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SuspendStart", c => c.DateTime());
            AddColumn("dbo.Customers", "SuspendEnd", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "SuspendEnd");
            DropColumn("dbo.Customers", "SuspendStart");
        }
    }
}
