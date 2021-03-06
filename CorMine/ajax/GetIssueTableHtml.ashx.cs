﻿
namespace CorMine.ajax 
{


    /// <summary>
    /// Zusammenfassungsbeschreibung für table
    /// </summary>
    public class GetIssueTableHtml : System.Web.IHttpHandler
    {
        

        public void ProcessRequest(System.Web.HttpContext context)
        {
            string html = @"<!DOCTYPE html>
<html xmlns=""http://www.w3.org/1999/xhtml"" lang=""en"">
<head>
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"" />

    <meta http-equiv=""cache-control"" content=""max-age=0"" />
    <meta http-equiv=""cache-control"" content=""no-cache"" />
    <meta http-equiv=""expires"" content=""0"" />
    <meta http-equiv=""expires"" content=""Tue, 01 Jan 1980 1:00:00 GMT"" />
    <meta http-equiv=""pragma"" content=""no-cache"" />

    <meta charset=""utf-8"" />
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />

    <meta http-equiv=""Content-Language"" content=""en"" />
    <meta name=""viewport"" content=""width=device-width,initial-scale=1"" />


    <!--
    <meta name=""author"" content=""name"" />
    <meta name=""description"" content=""description here"" />
    <meta name=""keywords"" content=""keywords,here"" />

    <link rel=""shortcut icon"" href=""favicon.ico"" type=""image/vnd.microsoft.icon"" />
    <link rel=""stylesheet"" href=""stylesheet.css"" type=""text/css"" />
    -->

    <title>Title</title>
    <style type=""text/css"" media=""all"">
        body
        {
            background-color: #0c70b4;
            color: #546775;
            font: normal 400 18px ""PT Sans"", sans-serif;
            -webkit-font-smoothing: antialiased;
        }
        
        /*
        #foo > div.Table-row.Table-header > div:nth-child(5),
        #foo > div.Table-row.Table-header > div:nth-child(6)
        {
            min-width: 15cm;
        }
        */

        div.Table-row-item[data-header='Description'], div.Table-row-item[data-header='Subject']
        {
            max-height: 1cm;
            overflow: hidden;
            #min-width: 15cm;
        }
        

        .Table 
        {
            display: -webkit-box;
            display: -moz-box;
            display: box;
            display: -webkit-flex;
            display: -moz-flex;
            display: -ms-flexbox;
            display: flex;
            -webkit-flex-flow: column nowrap;
            -moz-flex-flow: column nowrap;
            flex-flow: column nowrap;
            -webkit-box-pack: justify;
            -moz-box-pack: justify;
            box-pack: justify;
            -webkit-justify-content: space-between;
            -moz-justify-content: space-between;
            -ms-justify-content: space-between;
            -o-justify-content: space-between;
            justify-content: space-between;
            -ms-flex-pack: justify;
            border: 1px solid #f2f2f2;
            font-size: 1rem;
            margin: 0.5rem;
            line-height: 1.5;
        }

        .Table-header 
        {
            display: none;
        }


        @media (min-width: 500px) 
        {

            .Table-header 
            {
            font-weight: 700;
            background-color: #f2f2f2;
            }

        }


        .Table-row 
        {
            width: 100%;
        }

        .Table-row:nth-of-type(even) 
        {
            background-color: #f2f2f2;
        }

        .Table-row:nth-of-type(odd) 
        {
            background-color: #ffffff;
        }


        @media (min-width: 500px) 
        {

            .Table-row 
            {
                display: -webkit-box;
                display: -moz-box;
                display: box;
                display: -webkit-flex;
                display: -moz-flex;
                display: -ms-flexbox;
                display: flex;
                -webkit-flex-flow: row nowrap;
                -moz-flex-flow: row nowrap;
                flex-flow: row nowrap;
            }

            .Table-row:nth-of-type(even) 
            {
                background-color: #ffffff;
            }

            .Table-row:nth-of-type(odd) 
            {
                background-color: #f2f2f2;
            }
        }


        .Table-row-item 
        {
            display: -webkit-box;
            display: -moz-box;
            display: box;
            display: -webkit-flex;
            display: -moz-flex;
            display: -ms-flexbox;
            display: flex;
            -webkit-flex-flow: row nowrap;
            -moz-flex-flow: row nowrap;
            flex-flow: row nowrap;
            -webkit-flex-grow: 1;
            -moz-flex-grow: 1;
            flex-grow: 1;
            -ms-flex-positive: 1;
            -webkit-flex-basis: 0;
            -moz-flex-basis: 0;
            flex-basis: 0;
            -ms-flex-preferred-size: 0;
            word-wrap: break-word;
            overflow-wrap: break-word;
            word-break: break-all;
            padding: 0.5em;
            word-break: break-word;
        }

        .Table-row-item:before 
        {
            content: attr(data-header);
            width: 30%;
            font-weight: 700;
        }


        @media (min-width: 500px) 
        {

            .Table-row-item 
            {
            border: 1px solid #ffffff;
            padding: 0.5em;
            }

            .Table-row-item:before 
            {
            content: none;
            }

        }

    </style>
</head>
<body>
";

            // context.Response.ContentType = "text/html";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.ContentType = "text/html; charset=utf-8";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.Write(html);

            using (System.Data.DataTable data = Issues.GetDataTable())
            {
                string table = responsiveTable("foo", data);
                context.Response.Write(table);
                context.Response.Write(html);
            }

            context.Response.Write(@"</body>
</html>
");

        } // End Sub ProcessRequest 


        public static string responsiveTable(string id, System.Data.DataTable table)
        {
            string retVal = null;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            responsiveTable(id, table, sb);
            retVal = sb.ToString();
            sb.Length = 0;
            sb = null;
            return retVal;
        } // End Function responsiveTable 


        public static void responsiveTable(string id, System.Data.DataTable table, System.Text.StringBuilder sb)
        {

            sb.AppendLine(@"<div id=""" + System.Web.HttpUtility.HtmlAttributeEncode(id) + @""" class=""table"">");
            sb.AppendLine(@"<div class=""Table-row Table-header"">");
            foreach (System.Data.DataColumn dc in table.Columns)
            {
                sb.Append(@"<div class=""Table-row-item"">");
                sb.Append(System.Web.HttpUtility.HtmlEncode(dc.ColumnName));
                sb.AppendLine("</div>"); // End Header-Cell
            } // Next i 
            sb.AppendLine("</div>"); // End Header-Row

            foreach (System.Data.DataRow dr in table.Rows)
            {
                sb.AppendLine(@"<div class=""Table-row"">");

                foreach (System.Data.DataColumn dc in table.Columns)
                {
                    sb.Append(@"<div class=""Table-row-item"" data-header=""" + System.Web.HttpUtility.HtmlAttributeEncode(dc.ColumnName) + @""">");
                    sb.Append(System.Web.HttpUtility.HtmlEncode(System.Convert.ToString(dr[dc.ColumnName])));
                    sb.AppendLine("</div>"); // End Cell
                } // Next dc 

                sb.AppendLine("</div>"); // End Row
            } // Next dr  
            sb.AppendLine("</div>"); // End Table
        } // End Sub responsiveTable 


        public bool IsReusable
        {
            get
            {
                return false;
            }
        } // End Property IsReusable 


    } // End Class GetIssueTableHtml : System.Web.IHttpHandler 


} // End Namespace CorMine 
