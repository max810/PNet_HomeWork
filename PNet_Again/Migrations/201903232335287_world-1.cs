namespace PNet_Again.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class world1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FishSizes",
                c => new
                    {
                        FishId = c.Int(nullable: false),
                        Width = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        Length = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FishId)
                .ForeignKey("dbo.Fishes", t => t.FishId)
                .Index(t => t.FishId);
            
            CreateTable(
                "dbo.Fish11",
                c => new
                    {
                        FishId = c.Int(nullable: false),
                        FinType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FishId);
            
            DropColumn("dbo.Fishes", "FinType");
            DropColumn("dbo.Fishes", "Width");
            DropColumn("dbo.Fishes", "Height");
            DropColumn("dbo.Fishes", "Length");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fishes", "Length", c => c.Double(nullable: false));
            AddColumn("dbo.Fishes", "Height", c => c.Double(nullable: false));
            AddColumn("dbo.Fishes", "Width", c => c.Double(nullable: false));
            AddColumn("dbo.Fishes", "FinType", c => c.Int(nullable: false));
            DropForeignKey("dbo.FishSizes", "FishId", "dbo.Fishes");
            DropIndex("dbo.FishSizes", new[] { "FishId" });
            DropTable("dbo.Fish11");
            DropTable("dbo.FishSizes");
        }
    }
}
