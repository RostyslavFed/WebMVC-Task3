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
	public class ArticleTagRepository : IRepository<ArticleTag>
	{
		private BlogContext db;

		public ArticleTagRepository(BlogContext context)
		{
			this.db = context;
		}

		public void Create(ArticleTag item)
		{
			db.ArticleTags.Add(item);
		}

		public void Delete(int id)
		{
			ArticleTag articleTag = db.ArticleTags.Find(id);
			if (articleTag != null)
				db.ArticleTags.Remove(articleTag);
		}

		public IEnumerable<ArticleTag> Find(Func<ArticleTag, bool> predicate)
		{
			return db.ArticleTags.Where(predicate).ToList();
		}

		public ArticleTag Get(int id)
		{
			return db.ArticleTags.Find(id);
		}

		public IEnumerable<ArticleTag> GetAll()
		{
			return db.ArticleTags;
		}

		public void Update(ArticleTag item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}
