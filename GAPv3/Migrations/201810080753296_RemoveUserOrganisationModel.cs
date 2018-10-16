namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserOrganisationModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserOrganisations", "OrganisationId", "dbo.Organisations");
            DropForeignKey("dbo.UserOrganisations", "UserId", "dbo.Users");
            DropIndex("dbo.UserOrganisations", new[] { "UserId" });
            DropIndex("dbo.UserOrganisations", new[] { "OrganisationId" });
            DropTable("dbo.UserOrganisations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserOrganisations",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        OrganisationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.OrganisationId });
            
            CreateIndex("dbo.UserOrganisations", "OrganisationId");
            CreateIndex("dbo.UserOrganisations", "UserId");
            AddForeignKey("dbo.UserOrganisations", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.UserOrganisations", "OrganisationId", "dbo.Organisations", "OrganisationId", cascadeDelete: true);
        }
    }
}
