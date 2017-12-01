namespace LearningSystem.Services
{
    public class ServiceConstants
    {
        public const int AllArticlesPageSize = 25;

        public const string PdfCertinficateFormat = @"
              <h1>Certificate</h1>
              <h2>{3}- Grade {4}</h2>
              <br />
              <h2>{0} Course</h2>
              <h3>{1} - {2}</h3>
              <h4>Signed by {5}</h4>
              <h5>{6}</h5>";
    }
}
