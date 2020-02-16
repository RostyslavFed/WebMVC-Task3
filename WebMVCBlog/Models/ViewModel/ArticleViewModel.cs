using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBlog.DAL.Entities;

namespace WebMVCBlog.Models.ViewModel
{
	public class ArticleViewModel
	{
		public Article Article { get; set; }

		public List<string> Tags { get; set; }

		public bool FullDisplay { get; set; }
	}
}