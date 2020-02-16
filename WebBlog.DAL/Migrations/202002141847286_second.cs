namespace WebBlog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Text3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Text3");
        }
    }
}
