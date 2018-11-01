namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHomeMessageModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HomeMessages", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.HomeMessages", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HomeMessages", "Message", c => c.String());
            AlterColumn("dbo.HomeMessages", "Title", c => c.String());
        }
    }
}
