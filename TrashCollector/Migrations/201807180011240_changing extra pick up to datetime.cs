namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingextrapickuptodatetime : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "ExtraPickUpDay_DayID", "dbo.Days");
            DropIndex("dbo.Customers", new[] { "ExtraPickUpDay_DayID" });
            AddColumn("dbo.Customers", "ExtraPickUp", c => c.DateTime());
            DropColumn("dbo.Customers", "ExtraPickUpDay_DayID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ExtraPickUpDay_DayID", c => c.Int());
            DropColumn("dbo.Customers", "ExtraPickUp");
            CreateIndex("dbo.Customers", "ExtraPickUpDay_DayID");
            AddForeignKey("dbo.Customers", "ExtraPickUpDay_DayID", "dbo.Days", "DayID");
        }
    }
}
