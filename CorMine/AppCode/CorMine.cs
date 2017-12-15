
namespace CorMine
{


    public class Issues
    {

        // https://github.com/zapadi/redmine-net-api/blob/master/xUnitTest-redmine-net45-api/Tests/Sync/IssueTests.cs
        public static System.Collections.Generic.List<Redmine.Net.Api.Types.Issue> GetIssues(string project_id)
        {
            Redmine.Net.Api.RedmineManager redman = RedmineFactory.CreateInstance();
            
            System.Collections.Specialized.NameValueCollection parameters =
                new System.Collections.Specialized.NameValueCollection {
                    { "status_id", "*" } 
                    // ,{ Redmine.Net.Api.RedmineKeys.PROJECT_ID, project_id}
                };

            if(!string.IsNullOrEmpty(project_id))
                parameters[Redmine.Net.Api.RedmineKeys.PROJECT_ID] = project_id;


            // https://stackoverflow.com/questions/14839712/nginx-reverse-proxy-passthrough-basic-authenication
            // https://stackoverflow.com/questions/19751313/forward-request-headers-from-nginx-proxy-server


            return redman.GetObjects<Redmine.Net.Api.Types.Issue>(parameters);
        }


        public static System.Data.DataTable GetDataTable()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.TableName = "Issues";

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Project", typeof(string));
            dt.Columns.Add("Author", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Subject", typeof(string));
            dt.Columns.Add("Description", typeof(string));

            dt.Columns.Add("StartDate", typeof(System.DateTime));
            dt.Columns.Add("DueDate", typeof(System.DateTime));
            dt.Columns.Add("EstimatedHours", typeof(float));

            dt.Columns.Add("Gemeldet von", typeof(string));

            dt.Columns.Add("CreatedOn", typeof(System.DateTime));
            dt.Columns.Add("UpdatedOn", typeof(System.DateTime));
            dt.Columns.Add("ClosedOn", typeof(System.DateTime));
            dt.Columns.Add("Notes", typeof(string));
            dt.Columns.Add("AssignedTo", typeof(string));


            System.Collections.Generic.List<Redmine.Net.Api.Types.Issue> issues = GetIssues("113");

            foreach (Redmine.Net.Api.Types.Issue thisIssue in issues)
            {
                System.Data.DataRow dr = dt.NewRow();
                System.Console.WriteLine("#{0}: {1}", thisIssue.Id, thisIssue.Subject);

                try
                {
                    dr["Id"] = thisIssue.Id;

                    dr["Project"] = thisIssue.Project != null ? (object)thisIssue.Project.Name : System.DBNull.Value;
                    dr["Author"] = thisIssue.Author != null ? (object)thisIssue.Author.Name : System.DBNull.Value;
                    //thisIssue.Author.Id
                    dr["Category"] = thisIssue.Category != null ? (object)thisIssue.Category.Name : System.DBNull.Value;

                    dr["Subject"] = thisIssue.Subject;
                    dr["Description"] = thisIssue.Description;

                    dr["StartDate"] = thisIssue.StartDate.HasValue ? (object)thisIssue.StartDate.Value : (object)System.DBNull.Value;
                    dr["DueDate"] = thisIssue.DueDate.HasValue ? (object)thisIssue.DueDate.Value : (object)System.DBNull.Value;
                    dr["EstimatedHours"] = thisIssue.EstimatedHours.HasValue ? (object)thisIssue.EstimatedHours.Value : (object)System.DBNull.Value;

                    // thisIssue.CustomFields[Name="gemeldet von"].Values[0].Info;
                    if (thisIssue.CustomFields != null && thisIssue.CustomFields.Count > 0)
                    {
                        
                        for (int i = 0; i < thisIssue.CustomFields.Count; ++i)
                        {
                            if (thisIssue.CustomFields[i] != null && 
                                System.StringComparer.OrdinalIgnoreCase.Equals(
                                    thisIssue.CustomFields[i].Name, "gemeldet von")
                                    )
                            {
                                if (thisIssue.CustomFields[i].Values != null && thisIssue.CustomFields[i].Values.Count > 0)
                                {
                                    string gemeldetVon = thisIssue.CustomFields[0].Values[0].Info;
                                    dr["Gemeldet von"] = gemeldetVon;
                                }
                            }
                        }
                    }

                    

                    dr["CreatedOn"] = thisIssue.CreatedOn.HasValue ? (object)thisIssue.CreatedOn.Value : (object)System.DBNull.Value;
                    dr["UpdatedOn"] = thisIssue.UpdatedOn.HasValue ? (object)thisIssue.UpdatedOn.Value : (object)System.DBNull.Value;
                    dr["ClosedOn"] = thisIssue.ClosedOn.HasValue ? (object)thisIssue.ClosedOn.Value : (object)System.DBNull.Value;

                    dr["Notes"] = thisIssue.Notes;
                    dr["AssignedTo"] = thisIssue.AssignedTo != null ? (object)thisIssue.AssignedTo.Name : System.DBNull.Value;
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message, thisIssue);
                }

                dt.Rows.Add(dr);

            } // Next issue 

            return dt;
        }


    }


}
