using LearningSystem.Services.Blog.Models;
using System.Collections.Generic;

namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    public class AllArticlesViewModel
    {
        public IEnumerable<AllArticlesServiceModel> Articles { get; set; }

        public int TotalArticles { get; set; }

        public int CurrentPage { get; set; }

        public int PreviuosPage { get; set; }

        public int LastPage { get; set; }
    }
}
