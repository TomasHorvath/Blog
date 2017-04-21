namespace TomasHorvath.BlogEngine.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralizeSettings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogSetting", "Key", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.BlogSetting", "Value", c => c.String(nullable: false, maxLength: 300));
            AddColumn("dbo.BlogSetting", "DataType", c => c.String(maxLength: 150));
            DropColumn("dbo.BlogSetting", "BlogName");
            DropColumn("dbo.BlogSetting", "BlogMotto");
            DropColumn("dbo.BlogSetting", "BlogUrl");
            DropColumn("dbo.BlogSetting", "Keyword");
            DropColumn("dbo.BlogSetting", "Description");
            DropColumn("dbo.BlogSetting", "FacebookLink");
            DropColumn("dbo.BlogSetting", "TwitterLink");
            DropColumn("dbo.BlogSetting", "GithubLink");
            DropColumn("dbo.BlogSetting", "ContactEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogSetting", "ContactEmail", c => c.String(maxLength: 150));
            AddColumn("dbo.BlogSetting", "GithubLink", c => c.String(maxLength: 150));
            AddColumn("dbo.BlogSetting", "TwitterLink", c => c.String(maxLength: 150));
            AddColumn("dbo.BlogSetting", "FacebookLink", c => c.String(maxLength: 150));
            AddColumn("dbo.BlogSetting", "Description", c => c.String());
            AddColumn("dbo.BlogSetting", "Keyword", c => c.String());
            AddColumn("dbo.BlogSetting", "BlogUrl", c => c.String());
            AddColumn("dbo.BlogSetting", "BlogMotto", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.BlogSetting", "BlogName", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.BlogSetting", "DataType");
            DropColumn("dbo.BlogSetting", "Value");
            DropColumn("dbo.BlogSetting", "Key");
        }
    }
}
