namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserOrganisationRelationShipOneToMany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "OrganisationId", c => c.Int());
            CreateIndex("dbo.Users", "OrganisationId");
            AddForeignKey("dbo.Users", "OrganisationId", "dbo.Organisations", "OrganisationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "OrganisationId", "dbo.Organisations");
            DropIndex("dbo.Users", new[] { "OrganisationId" });
            DropColumn("dbo.Users", "OrganisationId");
        }
    }
}
