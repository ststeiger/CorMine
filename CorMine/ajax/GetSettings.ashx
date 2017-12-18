<%@ WebHandler Language="C#" Class="CorMine.ajax.GetSettings" %>

using System;
using System.Collections.Generic;
using System.Web;

namespace CorMine.ajax
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für GetSettings
    /// </summary>
    public class GetSettings : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain; charset=utf-8";

            string sql = @"
SELECT 
        id
       ,name
       ,value
       ,updated_on
FROM settings 
WHERE name = 'attachment_extensions_allowed' 
";

            context.Response.Write(sql);
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