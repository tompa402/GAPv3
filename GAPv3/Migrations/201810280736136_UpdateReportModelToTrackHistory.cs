namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReportModelToTrackHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "IsLocked", c => c.Boolean(nullable: false));
            AddColumn("dbo.Reports", "CreatedBy", c => c.String());
            AddColumn("dbo.Reports", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "ModifiedBy");
            DropColumn("dbo.Reports", "CreatedBy");
            DropColumn("dbo.Reports", "IsLocked");
        }
    }
}
