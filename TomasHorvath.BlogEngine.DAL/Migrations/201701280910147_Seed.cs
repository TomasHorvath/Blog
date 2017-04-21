namespace TomasHorvath.BlogEngine.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Headline = c.String(maxLength: 200),
                        Content = c.String(nullable: false),
                        Keyword = c.String(maxLength: 300),
                        Description = c.String(maxLength: 300),
                        DateOfPublished = c.DateTime(nullable: false),
                        AuthorId = c.String(nullable: false, maxLength: 128),
                        IsContantPage = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        DateOfCreated = c.DateTime(nullable: false),
                        DateOfChange = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Pages", new[] { "AuthorId" });
            DropTable("dbo.Pages");
        }
    }
}
