using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBlog.DAL.Entities;

namespace WebMVCBlog.Models.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<ArticleViewModel> ArticleVMs { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}