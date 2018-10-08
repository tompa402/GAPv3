namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrganisationRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organisations", "Ownership", c => c.String(nullable: false));
            AlterColumn("dbo.Organisations", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Organisations", "EmployeesNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Organisations", "Size", c => c.String(nullable: false));
            AlterColumn("dbo.Organisations", "GuardService", c => c.String(nullable: false));
            AlterColumn("dbo.Organisations", "VideoSurveillance", c => c.String(nullable: false));
            AlterColumn("dbo.Organisations", "BuildingPossession", c => c.String(nullable: false));
            AlterColumn("dbo.Organisations", "ITService", c => c.String(nullable: false));
            AlterColumn("dbo.Organisations", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Organisations", "AssetOne", c => c.String(nullable: false));
            AlterColumn("dbo.Organisations", "AssetTwo", c => c.String(nullable: false));
            AlterColumn("dbo.Organisations", "AssetThree", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organisations", "AssetThree", c => c.String());
            AlterColumn("dbo.Organisations", "AssetTwo", c => c.String());
            AlterColumn("dbo.Organisations", "AssetOne", c => c.String());
            AlterColumn("dbo.Organisations", "Location", c => c.String());
            AlterColumn("dbo.Organisations", "ITService", c => c.String());
            AlterColumn("dbo.Organisations", "BuildingPossession", c => c.String());
            AlterColumn("dbo.Organisations", "VideoSurveillance", c => c.String());
            AlterColumn("dbo.Organisations", "GuardService", c => c.String());
            AlterColumn("dbo.Organisations", "Size", c => c.String());
            AlterColumn("dbo.Organisations", "EmployeesNumber", c => c.String());
            AlterColumn("dbo.Organisations", "Type", c => c.String());
            AlterColumn("dbo.Organisations", "Ownership", c => c.String());
        }
    }
}
