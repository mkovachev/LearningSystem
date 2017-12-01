namespace LearningSystem.Services
{
    public class ServiceConstants
    {
        public const int AllArticlesPageSize = 25;

        public const string PdfCertinficateFormat = @"
              <h1>Certificate</h1>
              <h2>for {3}</h2>
              <h2>Graduated with Grade {4}</h2>
              <br />
              <h2>{0} Course</h2>
              <h4>{1} - {2}</h4>
              <h4>Signed by {5}</h4>
              <h5>Issued date: {6}</h5>";
    }
}
