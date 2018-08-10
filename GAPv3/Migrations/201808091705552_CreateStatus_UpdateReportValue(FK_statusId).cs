namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStatus_UpdateReportValueFK_statusId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            AddColumn("dbo.ReportValues", "StatusId", c => c.Int());
            CreateIndex("dbo.ReportValues", "StatusId");
            AddForeignKey("dbo.ReportValues", "StatusId", "dbo.Status", "StatusId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportValues", "StatusId", "dbo.Status");
            DropIndex("dbo.ReportValues", new[] { "StatusId" });
            DropColumn("dbo.ReportValues", "StatusId");
            DropTable("dbo.Status");
        }
    }
}
