namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserModelForHashCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Token", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Token");
        }
    }
}
