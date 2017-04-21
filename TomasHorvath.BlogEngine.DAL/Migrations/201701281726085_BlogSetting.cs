namespace TomasHorvath.BlogEngine.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogSetting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogSetting",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BlogName = c.String(nullable: false, maxLength: 150),
                        BlogMotto = c.String(nullable: false, maxLength: 150),
                        BlogUrl = c.String(),
                        Keyword = c.String(),
                        Description = c.String(),
                        FacebookLink = c.String(maxLength: 150),
                        TwitterLink = c.String(maxLength: 150),
                        GithubLink = c.String(maxLength: 150),
                        ContactEmail = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pages", "DisplayOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "DisplayOrder");
            DropTable("dbo.BlogSetting");
        }
    }
}
