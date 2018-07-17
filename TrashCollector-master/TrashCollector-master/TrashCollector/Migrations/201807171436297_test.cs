namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "ExtraDayID", "dbo.Days");
            DropIndex("dbo.Customers", new[] { "ExtraDayID" });

        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ExtraDayID", c => c.Int());
            CreateIndex("dbo.Customers", "ExtraDayID");
            AddForeignKey("dbo.Customers", "ExtraDayID", "dbo.Days", "DayID");
        }
    }
}
