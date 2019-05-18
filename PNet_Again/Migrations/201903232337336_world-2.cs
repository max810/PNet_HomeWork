namespace PNet_Again.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class world2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fishes", "FinType", c => c.Int(nullable: false));
            DropTable("dbo.Fish11");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Fish11",
                c => new
                    {
                        FishId = c.Int(nullable: false),
                        FinType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FishId);
            
            DropColumn("dbo.Fishes", "FinType");
        }
    }
}
