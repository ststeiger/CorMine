
namespace CorMine.ajax 
{


    /// <summary>
    /// Zusammenfassungsbeschreibung für GetUsers
    /// </summary>
    public class GetUsers : System.Web.IHttpHandler
    {


        public void ProcessRequest(System.Web.HttpContext context)
        {
            Redmine.Net.Api.RedmineManager redman = RedmineFactory.CreateInstance();

            System.Collections.Generic.List<Redmine.Net.Api.Types.User> users = 
                redman.GetObjects<Redmine.Net.Api.Types.User>();

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);

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