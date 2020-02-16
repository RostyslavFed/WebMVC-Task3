namespace WebBlog.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebBlog.DAL.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<WebBlog.DAL.EF.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebBlog.DAL.EF.BlogContext";
        }

        protected override void Seed(WebBlog.DAL.EF.BlogContext context)
        {
			
		}
    }
}
