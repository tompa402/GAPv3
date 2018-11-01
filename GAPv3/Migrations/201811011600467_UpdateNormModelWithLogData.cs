namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNormModelWithLogData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Norms", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Norms", "Modified", c => c.DateTime());
            AddColumn("dbo.Norms", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Norms", "CreatedBy", c => c.String());
            AddColumn("dbo.Norms", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Norms", "ModifiedBy");
            DropColumn("dbo.Norms", "CreatedBy");
            DropColumn("dbo.Norms", "IsActive");
            DropColumn("dbo.Norms", "Modified");
            DropColumn("dbo.Norms", "Created");
        }
    }
}
