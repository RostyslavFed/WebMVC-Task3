namespace WebBlog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Articles", "Text2");
            DropColumn("dbo.Articles", "Text3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Text3", c => c.String());
            AddColumn("dbo.Articles", "Text2", c => c.String());
        }
    }
}
