namespace TomasHorvath.BlogEngine.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Fullname", c => c.String());
            AddColumn("dbo.Comments", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Email");
            DropColumn("dbo.Comments", "Fullname");
        }
    }
}
