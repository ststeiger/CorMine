using System;
using System.Collections.Generic;
using System.Web;

namespace CorMine.ajax
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für GetFiltered
    /// </summary>
    public class GetFiltered : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string project_id = "6";

            Redmine.Net.Api.RedmineManager redman = RedmineFactory.CreateInstance();

            System.Collections.Specialized.NameValueCollection parameters =
                new System.Collections.Specialized.NameValueCollection {
                    //{ "status_id", "*" } 
                    // ,
                    { Redmine.Net.Api.RedmineKeys.PROJECT_ID, project_id}
                };

            /*
            if (!string.IsNullOrEmpty(project_id))
                parameters[Redmine.Net.Api.RedmineKeys.PROJECT_ID] = project_id;
            */

            // https://stackoverflow.com/questions/14839712/nginx-reverse-proxy-passthrough-basic-authenication
            // https://stackoverflow.com/questions/19751313/forward-request-headers-from-nginx-proxy-server


            System.Collections.Generic.List<Redmine.Net.Api.Types.Tracker> trackers = redman.GetObjects<Redmine.Net.Api.Types.Tracker>(parameters);
            foreach (Redmine.Net.Api.Types.Tracker thisTracker in trackers)
            {
                System.Console.WriteLine("#{0}: {1}", thisTracker.Id, thisTracker.Name);
            } // Next issue 

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(trackers, Newtonsoft.Json.Formatting.Indented);

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