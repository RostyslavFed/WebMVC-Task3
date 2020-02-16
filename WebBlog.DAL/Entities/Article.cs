using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBlog.DAL.Entities
{
	public class Article
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime PublicationDate { get; set; }
		public string Text { get; set; }
	}
}
