namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpgradeAdditionalReportItemsUpdate3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReportValueAdditionalItems", "Control_ControlId", "dbo.Controls");
            DropForeignKey("dbo.ReportValueAdditionalItems", "Reason_ReasonId", "dbo.Reasons");
            DropIndex("dbo.ReportValueAdditionalItems", new[] { "Control_ControlId" });
            DropIndex("dbo.ReportValueAdditionalItems", new[] { "Reason_ReasonId" });
            DropColumn("dbo.ReportValueAdditionalItems", "Control_ControlId");
            DropColumn("dbo.ReportValueAdditionalItems", "Reason_ReasonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReportValueAdditionalItems", "Reason_ReasonId", c => c.Int());
            AddColumn("dbo.ReportValueAdditionalItems", "Control_ControlId", c => c.Int());
            CreateIndex("dbo.ReportValueAdditionalItems", "Reason_ReasonId");
            CreateIndex("dbo.ReportValueAdditionalItems", "Control_ControlId");
            AddForeignKey("dbo.ReportValueAdditionalItems", "Reason_ReasonId", "dbo.Reasons", "ReasonId");
            AddForeignKey("dbo.ReportValueAdditionalItems", "Control_ControlId", "dbo.Controls", "ControlId");
        }
    }
}
