using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBlog.DAL.Entities
{
	public class ArticleTag
	{
		public int Id { get; set; }
		public Tag Tags { get; set; }
		public Article Articles { get; set; }
	}
}
