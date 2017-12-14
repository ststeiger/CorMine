
namespace CorMine.ajax
{


    /// <summary>
    /// Zusammenfassungsbeschreibung für GetIssues
    /// </summary>
    public class GetIssues : System.Web.IHttpHandler
    {

        public void ProcessRequest(System.Web.HttpContext context)
        {
            System.Collections.Generic.List<Redmine.Net.Api.Types.Issue> issues = Issues.GetIssues("");
            foreach (Redmine.Net.Api.Types.Issue thisIssue in issues)
            {
                System.Console.WriteLine("#{0}: {1}", thisIssue.Id, thisIssue.Subject);
            } // Next issue 

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(issues, Newtonsoft.Json.Formatting.Indented);

            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Write(json);
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


    }


}
