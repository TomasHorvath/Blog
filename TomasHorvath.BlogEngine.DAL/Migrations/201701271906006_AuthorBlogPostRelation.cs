namespace TomasHorvath.BlogEngine.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorBlogPostRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogPosts", "AuthorId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.BlogPosts", "AuthorId");
            AddForeignKey("dbo.BlogPosts", "AuthorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPosts", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.BlogPosts", new[] { "AuthorId" });
            DropColumn("dbo.BlogPosts", "AuthorId");
        }
    }
}
