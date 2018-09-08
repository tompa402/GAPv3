namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAndOrganisationModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organisations", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Organisations", "Ownership", c => c.String());
            AddColumn("dbo.Organisations", "Type", c => c.String());
            AddColumn("dbo.Organisations", "EmployeesNumber", c => c.String());
            AddColumn("dbo.Organisations", "Size", c => c.String());
            AddColumn("dbo.Organisations", "GuardService", c => c.String());
            AddColumn("dbo.Organisations", "VideoSurveillance", c => c.String());
            AddColumn("dbo.Organisations", "BuildingPossession", c => c.String());
            AddColumn("dbo.Organisations", "ITService", c => c.String());
            AddColumn("dbo.Organisations", "Location", c => c.String());
            AddColumn("dbo.Organisations", "AssetOne", c => c.String());
            AddColumn("dbo.Organisations", "AssetTwo", c => c.String());
            AddColumn("dbo.Organisations", "AssetThree", c => c.String());
            AddColumn("dbo.Organisations", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Organisations", "Modified", c => c.DateTime());
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.Users", "LastName", c => c.String());
            AddColumn("dbo.Users", "JMBAG", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Modified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Modified");
            DropColumn("dbo.Users", "Created");
            DropColumn("dbo.Users", "JMBAG");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Organisations", "Modified");
            DropColumn("dbo.Organisations", "Created");
            DropColumn("dbo.Organisations", "AssetThree");
            DropColumn("dbo.Organisations", "AssetTwo");
            DropColumn("dbo.Organisations", "AssetOne");
            DropColumn("dbo.Organisations", "Location");
            DropColumn("dbo.Organisations", "ITService");
            DropColumn("dbo.Organisations", "BuildingPossession");
            DropColumn("dbo.Organisations", "VideoSurveillance");
            DropColumn("dbo.Organisations", "GuardService");
            DropColumn("dbo.Organisations", "Size");
            DropColumn("dbo.Organisations", "EmployeesNumber");
            DropColumn("dbo.Organisations", "Type");
            DropColumn("dbo.Organisations", "Ownership");
            DropColumn("dbo.Organisations", "Address");
        }
    }
}
