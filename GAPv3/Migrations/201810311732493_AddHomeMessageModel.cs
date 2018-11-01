namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHomeMessageModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HomeMessages",
                c => new
                    {
                        HomeMessageId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Message = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HomeMessageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HomeMessages");
        }
    }
}
