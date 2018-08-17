namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReportNameLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reports", "Name", c => c.String(nullable: false, maxLength: 160));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reports", "Name", c => c.String());
        }
    }
}
