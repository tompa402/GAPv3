namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpgradeAdditionalReportItemsUpdate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReportValueAdditionalItems", new[] { "ReportValue_ReportId", "ReportValue_NormItemId" }, "dbo.ReportValues");
            DropIndex("dbo.ReportValueAdditionalItems", new[] { "ReportValue_ReportId", "ReportValue_NormItemId" });
            DropColumn("dbo.ReportValueAdditionalItems", "ReportValue_ReportId");
            DropColumn("dbo.ReportValueAdditionalItems", "ReportValue_NormItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReportValueAdditionalItems", "ReportValue_NormItemId", c => c.Int());
            AddColumn("dbo.ReportValueAdditionalItems", "ReportValue_ReportId", c => c.Int());
            CreateIndex("dbo.ReportValueAdditionalItems", new[] { "ReportValue_ReportId", "ReportValue_NormItemId" });
            AddForeignKey("dbo.ReportValueAdditionalItems", new[] { "ReportValue_ReportId", "ReportValue_NormItemId" }, "dbo.ReportValues", new[] { "ReportId", "NormItemId" });
        }
    }
}
