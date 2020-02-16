using WebBlog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using WebMVCBlog.Models.ViewModel;
using System.Linq;

namespace WebMVCBlog.App_Code
{
	public static class MyHelpers
	{
		#region DisplayArticles
		public static MvcHtmlString DisplayArticles(this HtmlHelper html, 
			IEnumerable<ArticleViewModel> articleVMs, Func<int, string> pageUrl, Func<int, string> fullDisplay)
		{
			StringBuilder result = new StringBuilder();
			bool b = true;

			foreach(var article in articleVMs)
			{
				TagBuilder tag = new TagBuilder("div");
				tag.AddCssClass("row m-3 p-3 col-md-10 bg-light border border-success d-md-inline-block");

				string clas = b ? "text-left" : "text-right";

				tag.InnerHtml += createDiv($"h5 font-italic {clas}", article.Article.Title).ToString();
				tag.InnerHtml += createDiv($"small {clas}", DateTime.Now.ToShortDateString()).ToString();
				tag.InnerHtml += dislpayTextAndTags(article, fullDisplay).ToString();

				result.Append(tag.ToString());
				b = !b;
			}

			return MvcHtmlString.Create(result.ToString());
		}

		private static TagBuilder dislpayTextAndTags(ArticleViewModel articleVM, Func<int, string> allTextUrl)
		{
			if (articleVM.Article.Text.Length < 200 || articleVM.FullDisplay)
			{
				string tags = String.Join(" ", articleVM.Tags);

				return createDiv("pl-2 pr-2 text-left", articleVM.Article.Text + tags);
			}
			else
			{
				TagBuilder tag = createDiv("pl-2 pr-2 text-left", articleVM.Article.Text.Substring(0, 200) + "... ");

				TagBuilder a = new TagBuilder("a");
				a.AddCssClass("btn btn-default");
				a.MergeAttribute("href", allTextUrl(articleVM.Article.Id));
				a.InnerHtml = "Подробнее";

				tag.InnerHtml += a.ToString();

				return tag;
			}
		}

		private static TagBuilder createDiv(string cssClass, string innerHtml)
		{
			TagBuilder tag = new TagBuilder("div");
			tag.AddCssClass(cssClass);
			tag.InnerHtml = innerHtml;
			return tag;
		}
		#endregion

		#region PageLinks
		public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
		{
			StringBuilder result = new StringBuilder();

			for (int i = 1; i <= pageInfo.TotalPages; i++)
			{
				TagBuilder tag = new TagBuilder("a");
				tag.MergeAttribute("href", pageUrl(i));
				tag.InnerHtml = i.ToString();
				// если текущая страница, то выделяем ее,
				// например, добавляя класс
				if (i == pageInfo.PageNumber)
				{
					tag.AddCssClass("selected");
					tag.AddCssClass("btn-primary");
				}
				tag.AddCssClass("btn btn-default");
				result.Append(tag.ToString());
			}

			return MvcHtmlString.Create(result.ToString());
		}
		#endregion

		#region GetListCheckBox
		public static MvcHtmlString GetListCheckBox(this HtmlHelper html, List<string> items, string name)
		{
			TagBuilder result = new TagBuilder("div");
			result.AddCssClass("form-group row");

			result.InnerHtml += getDiv().ToString();
			result.InnerHtml += getList(items, name).ToString();

			return new MvcHtmlString(result.ToString());
		}

		private static TagBuilder getList(List<string> items, string name)
		{
			TagBuilder ul = new TagBuilder("ul");
			ul.AddCssClass("list-group row");

			foreach (var i in items)
			{
				TagBuilder li = new TagBuilder("li");
				li.AddCssClass("list-group-item row");

				TagBuilder input = new TagBuilder("input");
				input.AddCssClass("form-check-input col-md-offset-2 col-md-2");
				input.Attributes["name"] = name;
				input.Attributes["type"] = "checkbox";
				input.Attributes["value"] = i;
				li.InnerHtml += input.ToString();

				TagBuilder label = new TagBuilder("label");
				label.AddCssClass("col-md-2");
				label.SetInnerText(i);
				li.InnerHtml += label.ToString();

				ul.InnerHtml += li.ToString();
			}

			return ul;
		}

		private static TagBuilder getDiv()
		{
			TagBuilder div = new TagBuilder("div");
			div.AddCssClass("col-md-4");

			TagBuilder label = new TagBuilder("label");
			label.SetInnerText("Язык програмирования");

			div.InnerHtml += label.ToString();
			return div;
		}
		#endregion
	}
}