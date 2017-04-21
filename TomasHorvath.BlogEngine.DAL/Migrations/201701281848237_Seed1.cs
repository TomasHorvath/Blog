namespace TomasHorvath.BlogEngine.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "Name");
        }
    }
}
