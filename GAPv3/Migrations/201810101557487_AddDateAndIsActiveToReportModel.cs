namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAndIsActiveToReportModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reports", "Modified", c => c.DateTime());
            AddColumn("dbo.Reports", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "IsActive");
            DropColumn("dbo.Reports", "Modified");
            DropColumn("dbo.Reports", "Created");
        }
    }
}
