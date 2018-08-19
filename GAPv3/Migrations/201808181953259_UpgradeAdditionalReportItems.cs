namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpgradeAdditionalReportItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Controls",
                c => new
                    {
                        ControlId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ControlId);
            
            CreateTable(
                "dbo.ReportValueAdditionalItems",
                c => new
                    {
                        NormId = c.Int(nullable: false),
                        HaveReason = c.Boolean(nullable: false),
                        HaveControl = c.Boolean(nullable: false),
                        Control_ControlId = c.Int(),
                        ReportValue_ReportId = c.Int(),
                        ReportValue_NormItemId = c.Int(),
                        Reason_ReasonId = c.Int(),
                    })
                .PrimaryKey(t => new { t.NormId, t.HaveReason, t.HaveControl })
                .ForeignKey("dbo.Controls", t => t.Control_ControlId)
                .ForeignKey("dbo.ReportValues", t => new { t.ReportValue_ReportId, t.ReportValue_NormItemId })
                .ForeignKey("dbo.Reasons", t => t.Reason_ReasonId)
                .Index(t => t.Control_ControlId)
                .Index(t => new { t.ReportValue_ReportId, t.ReportValue_NormItemId })
                .Index(t => t.Reason_ReasonId);
            
            CreateTable(
                "dbo.Reasons",
                c => new
                    {
                        ReasonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ReasonId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.ReportValues", "ControlId", c => c.Int());
            AddColumn("dbo.ReportValues", "ReasonId", c => c.Int());
            CreateIndex("dbo.ReportValues", "ControlId");
            CreateIndex("dbo.ReportValues", "ReasonId");
            AddForeignKey("dbo.ReportValues", "ControlId", "dbo.Controls", "ControlId");
            AddForeignKey("dbo.ReportValues", "ReasonId", "dbo.Reasons", "ReasonId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportValues", "ReasonId", "dbo.Reasons");
            DropForeignKey("dbo.ReportValueAdditionalItems", "Reason_ReasonId", "dbo.Reasons");
            DropForeignKey("dbo.ReportValues", "ControlId", "dbo.Controls");
            DropForeignKey("dbo.ReportValueAdditionalItems", new[] { "ReportValue_ReportId", "ReportValue_NormItemId" }, "dbo.ReportValues");
            DropForeignKey("dbo.ReportValueAdditionalItems", "Control_ControlId", "dbo.Controls");
            DropIndex("dbo.ReportValues", new[] { "ReasonId" });
            DropIndex("dbo.ReportValues", new[] { "ControlId" });
            DropIndex("dbo.ReportValueAdditionalItems", new[] { "Reason_ReasonId" });
            DropIndex("dbo.ReportValueAdditionalItems", new[] { "ReportValue_ReportId", "ReportValue_NormItemId" });
            DropIndex("dbo.ReportValueAdditionalItems", new[] { "Control_ControlId" });
            DropColumn("dbo.ReportValues", "ReasonId");
            DropColumn("dbo.ReportValues", "ControlId");
            DropTable("dbo.Users");
            DropTable("dbo.Reasons");
            DropTable("dbo.ReportValueAdditionalItems");
            DropTable("dbo.Controls");
        }
    }
}
