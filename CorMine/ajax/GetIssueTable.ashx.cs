
namespace CorMine.ajax
{


    /// <summary>
    /// Zusammenfassungsbeschreibung für GetIssueTable
    /// </summary>
    public class GetIssueTable : System.Web.IHttpHandler
    {

        public void ProcessRequest(System.Web.HttpContext context)
        {
            using (System.Data.DataTable dt = Issues.GetDataTable())
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);

                context.Response.ContentEncoding = System.Text.Encoding.UTF8;
                context.Response.ContentType = "application/json; charset=utf-8";
                context.Response.Write(json);
            }
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
