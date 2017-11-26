using Ganss.XSS;
using LearningSystem.Services.Html.Contracts;

namespace LearningSystem.Services.Html.Services
{
    public class HtmlService : IHtmlService
    {
        private readonly HtmlSanitizer htmlSanitizer;

        public HtmlService()
        {
            this.htmlSanitizer = new HtmlSanitizer();
            this.htmlSanitizer.AllowedAttributes.Add("class");
        }

        public string Sanitize(string htmlContent)
        {
            return this.htmlSanitizer.Sanitize(htmlContent);
        }
    }
}
