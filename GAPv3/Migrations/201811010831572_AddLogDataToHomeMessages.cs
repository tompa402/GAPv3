namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogDataToHomeMessages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HomeMessages", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.HomeMessages", "Modified", c => c.DateTime());
            AddColumn("dbo.HomeMessages", "CreatedBy", c => c.String());
            AddColumn("dbo.HomeMessages", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HomeMessages", "ModifiedBy");
            DropColumn("dbo.HomeMessages", "CreatedBy");
            DropColumn("dbo.HomeMessages", "Modified");
            DropColumn("dbo.HomeMessages", "Created");
        }
    }
}
