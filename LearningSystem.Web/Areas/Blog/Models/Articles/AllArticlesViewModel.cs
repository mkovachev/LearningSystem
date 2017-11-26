using LearningSystem.Services;
using LearningSystem.Services.Blog.Models;
using System;
using System.Collections.Generic;

namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    public class AllArticlesViewModel
    {
        public IEnumerable<AllArticlesServiceModel> Articles { get; set; }

        public int TotalArticles { get; set; }

        public int TotalPage => (int)Math.Ceiling((double)this.TotalArticles / ServiceConstants.AllArticlesPageSize);

        public int CurrentPage { get; set; }

        public int PreviuosPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int LastPage => this.CurrentPage == this.TotalPage ? this.TotalPage : this.CurrentPage + 1;
    }
}
