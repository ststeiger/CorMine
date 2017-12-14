
namespace CorMine.ajax 
{


    /// <summary>
    /// Zusammenfassungsbeschreibung für GetProjects
    /// </summary>
    public class GetProjects : System.Web.IHttpHandler
    {
        
        static string RemoveDiacritics(string text)
        {
            string normalizedString = text.Normalize(System.Text.NormalizationForm.FormD);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            foreach (char c in normalizedString)
            {
                System.Globalization.UnicodeCategory unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                } // End if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark) 

            } // Next c 

            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC);
        } // End Function RemoveDiacritics 


        public static string GenerateVariableSlug(string phrase)
        {
            string str = RemoveDiacritics(phrase).ToLowerInvariant();
            // invalid chars           
            str = System.Text.RegularExpressions.Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s", "_"); // hyphens   
            str = str.Replace("-", "_");


            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("^[0-9].*");
            if (reg.IsMatch(str))
                str = "___" + str;

            return str;
        } // End Function GenerateVariableSlug 


        public void ProcessRequest(System.Web.HttpContext context)
        {
            Redmine.Net.Api.RedmineManager redman = RedmineFactory.CreateInstance();

            System.Collections.Generic.List<Redmine.Net.Api.Types.Project> projects = 
                redman.GetObjects<Redmine.Net.Api.Types.Project>(100, 0);

            //foreach (Redmine.Net.Api.Types.Project thisProject in projects)
            //{
            //    string str = "public static Redmine.Net.Api.Types.IdentifiableName " + GenerateVariableSlug(thisProject.Identifier) + " = new Redmine.Net.Api.Types.IdentifiableName() { Id = " + thisProject.Id + " };";
            //    System.Console.WriteLine(str);
            //} // Next thisProject 

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(projects, Newtonsoft.Json.Formatting.Indented);

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
