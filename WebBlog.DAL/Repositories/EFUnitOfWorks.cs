using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlog.DAL.EF;
using WebBlog.DAL.Entities;
using WebBlog.DAL.Interfaces;

namespace WebBlog.DAL.Repositories
{
	public class EFUnitOfWork : IUnitOfWork
	{
		private BlogContext db;
		private ArticleRepository articleRepository;
		private CommentRepository commentRepository;
		private TagRepository tagRepository;
		private ArticleTagRepository articleTagRepository;

		public EFUnitOfWork(string connectionString)
		{
			db = new BlogContext(connectionString);
		}

		public IRepository<Article> Articles
		{
			get
			{
				if (articleRepository == null)
					articleRepository = new ArticleRepository(db);
				return articleRepository;
			}
		}

		public IRepository<Comment> Comments
		{
			get
			{
				if (commentRepository == null)
					commentRepository = new CommentRepository(db);
				return commentRepository;
			}
		}

		public IRepository<Tag> Tags
		{
			get
			{
				if (tagRepository == null)
					tagRepository = new TagRepository(db);
				return tagRepository;
			}
		}

		public IRepository<ArticleTag> ArticleTags
		{
			get
			{
				if (articleRepository == null) articleRepository = new ArticleRepository(db);
				if (tagRepository == null) tagRepository = new TagRepository(db);

				if (articleTagRepository == null)
					articleTagRepository = new ArticleTagRepository(db);
				return articleTagRepository;
			}
		}

		public void Save()
		{
			db.SaveChanges();
		}

		private bool disposed = false;
		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
					db.Dispose();
				this.disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
