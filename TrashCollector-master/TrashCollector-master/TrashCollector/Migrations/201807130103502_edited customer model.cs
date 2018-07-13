namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedcustomermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserID", c => c.String());
            DropColumn("dbo.Customers", "Phone");
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Password", c => c.String());
            AddColumn("dbo.Customers", "Email", c => c.String());
            AddColumn("dbo.Customers", "Phone", c => c.String());
            DropColumn("dbo.Customers", "UserID");
        }
    }
}
