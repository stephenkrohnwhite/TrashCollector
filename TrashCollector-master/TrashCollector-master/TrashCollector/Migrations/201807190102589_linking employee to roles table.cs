namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linkingemployeetorolestable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "UserID");
        }
    }
}
