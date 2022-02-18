namespace WebRole1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchemaAndDataAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TitleData",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        TitleId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.TitleMaster", t => t.TitleId)
                .ForeignKey("dbo.UserData", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TitleId);
            
            CreateTable(
                "dbo.TitleMaster",
                c => new
                    {
                        TitleId = c.String(nullable: false, maxLength: 128),
                        TitleName = c.String(),
                        NumberOfWins = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TitleId);
            
            CreateTable(
                "dbo.UserData",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        NumberOfWins = c.Int(nullable: false),
                        NumberOfDefaeats = c.Int(nullable: false),
                        NumberOfDraws = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TitleData", "UserId", "dbo.UserData");
            DropForeignKey("dbo.TitleData", "TitleId", "dbo.TitleMaster");
            DropIndex("dbo.TitleData", new[] { "TitleId" });
            DropIndex("dbo.TitleData", new[] { "UserId" });
            DropTable("dbo.UserData");
            DropTable("dbo.TitleMaster");
            DropTable("dbo.TitleData");
        }
    }
}
