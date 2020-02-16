namespace WebBlog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class six : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Articles", "AllText");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "AllText", c => c.Boolean(nullable: false));
        }
    }
}
