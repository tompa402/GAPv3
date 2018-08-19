namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpgradeAdditionalReportItemsUpdate1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ReportValueAdditionalItems", "NormId");
            AddForeignKey("dbo.ReportValueAdditionalItems", "NormId", "dbo.Norms", "NormId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportValueAdditionalItems", "NormId", "dbo.Norms");
            DropIndex("dbo.ReportValueAdditionalItems", new[] { "NormId" });
        }
    }
}
