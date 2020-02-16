using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlog.DAL.Entities;

namespace WebBlog.DAL.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<Article> Articles { get; }
		IRepository<Comment> Comments { get; }
		IRepository<Tag> Tags { get; }
		IRepository<ArticleTag> ArticleTags { get; }
		void Save();
	}
}
