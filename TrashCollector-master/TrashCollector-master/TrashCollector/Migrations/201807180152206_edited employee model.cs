namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedemployeemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Zipcode", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Password", c => c.String());
            DropColumn("dbo.Employees", "Zipcode");
        }
    }
}
