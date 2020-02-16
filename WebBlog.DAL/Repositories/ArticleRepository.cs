using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlog.DAL.EF;
using WebBlog.DAL.Entities;
using WebBlog.DAL.Interfaces;

namespace WebBlog.DAL.Repositories
{
	public class ArticleRepository : IRepository<Article>
	{
		private BlogContext db;

		public ArticleRepository(BlogContext context)
		{
			this.db = context;
		}

		public IEnumerable<Article> GetAll()
		{
			return db.Articles;
		}

		public Article Get(int id)
		{
			return db.Articles.Find(id);
		}

		public void Create(Article article)
		{
			db.Articles.Add(article);
		}

		public void Update(Article article)
		{
			db.Entry(article).State = EntityState.Modified;
		}

		public IEnumerable<Article> Find(Func<Article, bool> predicate)
		{
			return db.Articles.Where(predicate).ToList();
		}

		public void Delete(int id)
		{
			Article article = db.Articles.Find(id);
			if (article != null)
				db.Articles.Remove(article);
		}
	}
}
