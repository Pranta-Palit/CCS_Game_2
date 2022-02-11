namespace WebRole1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allForeignKeyAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TitleMaster", "TitleId", c => c.String(maxLength: 128));
            CreateIndex("dbo.TitleMaster", "TitleId");
            AddForeignKey("dbo.TitleMaster", "TitleId", "dbo.TitleDataHeld", "TitleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TitleMaster", "TitleId", "dbo.TitleDataHeld");
            DropIndex("dbo.TitleMaster", new[] { "TitleId" });
            AlterColumn("dbo.TitleMaster", "TitleId", c => c.String());
        }
    }
}
