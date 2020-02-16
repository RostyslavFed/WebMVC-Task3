using Blog.DAL.Entities;
using Blog.DAL.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlog.DAL.Interfaces;
using WebBlog.DAL.Repositories;

namespace WebBlog.DAL.Util
{
	public class NinjectRegistrations : NinjectModule
	{
		public override void Load()
		{
			//Bind<IRepository>().To<ArticleRepository>();
		}
	}
}
