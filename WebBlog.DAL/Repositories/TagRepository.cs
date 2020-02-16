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
	public class TagRepository : IRepository<Tag>
	{
		private BlogContext db;

		public TagRepository(BlogContext context)
		{
			this.db = context;
		}

		public void Create(Tag item)
		{
			db.Tags.Add(item);
		}

		public void Delete(int id)
		{
			Tag tag = db.Tags.Find(id);
			if (tag != null)
				db.Tags.Remove(tag);
		}

		public IEnumerable<Tag> Find(Func<Tag, bool> predicate)
		{
			return db.Tags.Where(predicate).ToList();
		}

		public Tag Get(int id)
		{
			return db.Tags.Find(id);
		}

		public IEnumerable<Tag> GetAll()
		{
			return db.Tags;
		}

		public void Update(Tag item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}
