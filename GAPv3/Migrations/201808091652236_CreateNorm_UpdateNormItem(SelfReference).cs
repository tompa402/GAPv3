namespace GAPv3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNorm_UpdateNormItemSelfReference : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Norms",
                c => new
                    {
                        NormId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.NormId);
            
            AddColumn("dbo.NormItems", "NormId", c => c.Int(nullable: false));
            AddColumn("dbo.Reports", "NormId", c => c.Int(nullable: false));
            CreateIndex("dbo.NormItems", "NormId");
            CreateIndex("dbo.NormItems", "ParentId");
            CreateIndex("dbo.Reports", "NormId");
            AddForeignKey("dbo.NormItems", "ParentId", "dbo.NormItems", "NormItemId");
            AddForeignKey("dbo.NormItems", "NormId", "dbo.Norms", "NormId", cascadeDelete: true);
            AddForeignKey("dbo.Reports", "NormId", "dbo.Norms", "NormId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "NormId", "dbo.Norms");
            DropForeignKey("dbo.NormItems", "NormId", "dbo.Norms");
            DropForeignKey("dbo.NormItems", "ParentId", "dbo.NormItems");
            DropIndex("dbo.Reports", new[] { "NormId" });
            DropIndex("dbo.NormItems", new[] { "ParentId" });
            DropIndex("dbo.NormItems", new[] { "NormId" });
            DropColumn("dbo.Reports", "NormId");
            DropColumn("dbo.NormItems", "NormId");
            DropTable("dbo.Norms");
        }
    }
}
