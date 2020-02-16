using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebMVCBlog.Models;
using WebBlog.DAL.Repositories;
using WebBlog.DAL.Entities;
using System.Linq;
using WebMVCBlog.Models.ViewModel;

namespace WebMVCBlog.Controllers
{
	public class HomeController : Controller
	{
		private EFUnitOfWork eFunitOfWork;
		private List<int> fullDidplayIds;

		public HomeController()
		{
			eFunitOfWork = new EFUnitOfWork("BlogContext");
			fullDidplayIds = new List<int>();
		}

		public ActionResult Index(int page = 1, int fullDisplayId = -1)
		{
			int pageSize = 3; // количество объектов на страницу

			if (fullDisplayId != -1) fullDidplayIds.Add(fullDisplayId);

			List<ArticleViewModel> articleVMs = new List<ArticleViewModel>();
			List<Article> articlesPerPages = eFunitOfWork.Articles.GetAll().Skip((page - 1) * pageSize).Take(pageSize).ToList();
			foreach (var a in articlesPerPages)
			{
				List<Tag> Tags1 = eFunitOfWork.Tags.GetAll().ToList();///?????

				List<string> tags = eFunitOfWork.ArticleTags.GetAll().Where(at => at.Articles == a).Select(at => at.Tags.Name).ToList();

				articleVMs.Add(new ArticleViewModel
				{
					Article = a,
					Tags = tags,
					FullDisplay = fullDidplayIds.IndexOf(a.Id) > -1
				});
			}

			PageInfo pageInfo = new PageInfo
			{
				PageNumber = page, 
				PageSize = pageSize, 
				TotalItems = eFunitOfWork.Articles.GetAll().Count() 
			};
			IndexViewModel ivm = new IndexViewModel
			{
				PageInfo = pageInfo,
				ArticleVMs = articleVMs
			};

			ViewBag.Title = "Home Page";
			return View(ivm);
		}

		public ActionResult Guest()
		{
			ViewBag.Title = "Guest";
			return View(eFunitOfWork.Comments.GetAll());
		}

		[HttpGet]
		public ActionResult Questionnaire()
		{
			ViewBag.Title = "Questionnaire";
			return View();
		}

		[HttpPost]
		public string Questionnaire(Summary summary)
		{
			return summary.GetHtmlResult();
		}
	}
}