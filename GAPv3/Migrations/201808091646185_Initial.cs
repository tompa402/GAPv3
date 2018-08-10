namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NormItems",
                c => new
                    {
                        NormItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsItem = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.NormItemId);
            
            CreateTable(
                "dbo.ReportValues",
                c => new
                    {
                        ReportId = c.Int(nullable: false),
                        NormItemId = c.Int(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => new { t.ReportId, t.NormItemId })
                .ForeignKey("dbo.NormItems", t => t.NormItemId, cascadeDelete: false)
                .ForeignKey("dbo.Reports", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.ReportId)
                .Index(t => t.NormItemId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ReportId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportValues", "ReportId", "dbo.Reports");
            DropForeignKey("dbo.ReportValues", "NormItemId", "dbo.NormItems");
            DropIndex("dbo.ReportValues", new[] { "NormItemId" });
            DropIndex("dbo.ReportValues", new[] { "ReportId" });
            DropTable("dbo.Reports");
            DropTable("dbo.ReportValues");
            DropTable("dbo.NormItems");
        }
    }
}
