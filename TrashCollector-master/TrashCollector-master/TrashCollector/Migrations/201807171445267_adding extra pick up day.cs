namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingextrapickupday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ExtraPickUpDay_DayID", c => c.Int());
            CreateIndex("dbo.Customers", "ExtraPickUpDay_DayID");
            AddForeignKey("dbo.Customers", "ExtraPickUpDay_DayID", "dbo.Days", "DayID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ExtraPickUpDay_DayID", "dbo.Days");
            DropIndex("dbo.Customers", new[] { "ExtraPickUpDay_DayID" });
            DropColumn("dbo.Customers", "ExtraPickUpDay_DayID");
        }
    }
}
