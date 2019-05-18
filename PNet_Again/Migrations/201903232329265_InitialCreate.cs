namespace PNet_Again.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fishes",
                c => new
                    {
                        FishId = c.Int(nullable: false, identity: true),
                        RiverId = c.Int(nullable: false),
                        ShortName = c.String(),
                        FinType = c.Int(nullable: false),
                        ScientificName = c.String(),
                        Width = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        Length = c.Double(nullable: false),
                        HasBag = c.Boolean(nullable: false),
                        AverageSpeed = c.Double(nullable: false),
                        AverageDepth = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FishId)
                .ForeignKey("dbo.Rivers", t => t.RiverId, cascadeDelete: true)
                .Index(t => t.RiverId);
            
            CreateTable(
                "dbo.Rivers",
                c => new
                    {
                        RiverId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RiverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fishes", "RiverId", "dbo.Rivers");
            DropIndex("dbo.Fishes", new[] { "RiverId" });
            DropTable("dbo.Rivers");
            DropTable("dbo.Fishes");
        }
    }
}
