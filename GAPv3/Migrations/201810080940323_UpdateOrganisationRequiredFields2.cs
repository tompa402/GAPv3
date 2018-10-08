namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrganisationRequiredFields2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organisations", "Location", c => c.String());
            AlterColumn("dbo.Organisations", "AssetOne", c => c.String());
            AlterColumn("dbo.Organisations", "AssetTwo", c => c.String());
            AlterColumn("dbo.Organisations", "AssetThree", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organisations", "AssetThree", c => c.String(nullable: false));
            AlterColumn("dbo.Organisations", "AssetTwo", c => c.String(nullable: false));
            AlterColumn("dbo.Organisations", "AssetOne", c => c.String(nullable: false));
            AlterColumn("dbo.Organisations", "Location", c => c.String(nullable: false));
        }
    }
}
