﻿
namespace CorMine.ajax 
{


    /// <summary>
    /// Zusammenfassungsbeschreibung für GetPriorities
    /// </summary>
    public class GetPriorities : System.Web.IHttpHandler
    {


        public void ProcessRequest(System.Web.HttpContext context)
        {
            Redmine.Net.Api.RedmineManager redman = RedmineFactory.CreateInstance();

            System.Collections.Generic.List<Redmine.Net.Api.Types.IssuePriority> priorities = 
                redman.GetObjects<Redmine.Net.Api.Types.IssuePriority>();

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(priorities, Newtonsoft.Json.Formatting.Indented);

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