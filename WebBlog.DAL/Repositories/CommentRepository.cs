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
	public class CommentRepository : IRepository<Comment>
	{
		private BlogContext db;

		public CommentRepository(BlogContext context)
		{
			this.db = context;
		}

		public void Create(Comment comment)
		{
			db.Comments.Add(comment);
		}

		public void Delete(int id)
		{
			Comment comment = db.Comments.Find(id);
			if (comment != null)
				db.Comments.Remove(comment);
		}

		public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
		{
			return db.Comments.Where(predicate).ToList();
		}

		public Comment Get(int id)
		{
			return db.Comments.Find(id);
		}

		public IEnumerable<Comment> GetAll()
		{
			return db.Comments;
		}

		public void Update(Comment comment)
		{
			db.Entry(comment).State = EntityState.Modified;
		}
	}
}
