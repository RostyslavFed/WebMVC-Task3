namespace WebBlog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class five : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Articles_Id = c.Int(),
                        Tags_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.Articles_Id)
                .ForeignKey("dbo.Tags", t => t.Tags_Id)
                .Index(t => t.Articles_Id)
                .Index(t => t.Tags_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleTags", "Tags_Id", "dbo.Tags");
            DropForeignKey("dbo.ArticleTags", "Articles_Id", "dbo.Articles");
            DropIndex("dbo.ArticleTags", new[] { "Tags_Id" });
            DropIndex("dbo.ArticleTags", new[] { "Articles_Id" });
            DropTable("dbo.Tags");
            DropTable("dbo.ArticleTags");
        }
    }
}
