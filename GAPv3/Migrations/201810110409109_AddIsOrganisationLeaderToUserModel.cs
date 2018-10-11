namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsOrganisationLeaderToUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsOrganisationLeader", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsOrganisationLeader");
        }
    }
}
