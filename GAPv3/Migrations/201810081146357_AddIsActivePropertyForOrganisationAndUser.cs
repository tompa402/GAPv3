namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActivePropertyForOrganisationAndUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organisations", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "Token");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Token", c => c.String());
            DropColumn("dbo.Users", "IsActive");
            DropColumn("dbo.Organisations", "IsActive");
        }
    }
}
