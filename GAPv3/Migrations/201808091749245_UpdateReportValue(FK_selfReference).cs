namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReportValueFK_selfReference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReportValues", "ReportValue_ReportId", c => c.Int());
            AddColumn("dbo.ReportValues", "ReportValue_NormItemId", c => c.Int());
            CreateIndex("dbo.ReportValues", new[] { "ReportValue_ReportId", "ReportValue_NormItemId" });
            AddForeignKey("dbo.ReportValues", new[] { "ReportValue_ReportId", "ReportValue_NormItemId" }, "dbo.ReportValues", new[] { "ReportId", "NormItemId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportValues", new[] { "ReportValue_ReportId", "ReportValue_NormItemId" }, "dbo.ReportValues");
            DropIndex("dbo.ReportValues", new[] { "ReportValue_ReportId", "ReportValue_NormItemId" });
            DropColumn("dbo.ReportValues", "ReportValue_NormItemId");
            DropColumn("dbo.ReportValues", "ReportValue_ReportId");
        }
    }
}
