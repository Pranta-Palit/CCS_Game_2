namespace WebRole1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FkeyTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TitleDataHeld",
                c => new
                    {
                        TitleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TitleId)
                .ForeignKey("dbo.UserData", t => t.UserId)
                .Index(t => t.UserId);
            
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
            
            CreateTable(
                "dbo.TitleMaster",
                c => new
                    {
                        SchoolTitle = c.String(nullable: false, maxLength: 128),
                        TitleId = c.String(),
                        NumberOfWins = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SchoolTitle);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TitleDataHeld", "UserId", "dbo.UserData");
            DropIndex("dbo.TitleDataHeld", new[] { "UserId" });
            DropTable("dbo.TitleMaster");
            DropTable("dbo.UserData");
            DropTable("dbo.TitleDataHeld");
        }
    }
}
