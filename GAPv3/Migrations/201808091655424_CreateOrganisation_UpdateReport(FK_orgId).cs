namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateOrganisation_UpdateReportFK_orgId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organisations",
                c => new
                    {
                        OrganisationId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrganisationId);
            
            AddColumn("dbo.Reports", "OrganisationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reports", "OrganisationId");
            AddForeignKey("dbo.Reports", "OrganisationId", "dbo.Organisations", "OrganisationId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "OrganisationId", "dbo.Organisations");
            DropIndex("dbo.Reports", new[] { "OrganisationId" });
            DropColumn("dbo.Reports", "OrganisationId");
            DropTable("dbo.Organisations");
        }
    }
}
