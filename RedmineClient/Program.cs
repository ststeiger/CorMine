
namespace RedmineClient
{


    static class Program
    {

        public static void TestConnectionString()
        {
            System.Data.SqlClient.SqlConnectionStringBuilder csb = new System.Data.SqlClient.SqlConnectionStringBuilder();
            csb.DataSource = @"CORDB2016\SDM,1532";
            csb.DataSource = System.Environment.MachineName+ @"\SQLEXPRESS";
            csb.InitialCatalog = "Redmine";
            csb.IntegratedSecurity = true;
            if (!csb.IntegratedSecurity)
            {
                csb.UserID = "RedmineWebServices";
                csb.Password = "TOP_Secret";
            }

            csb.PersistSecurityInfo = false;
            csb.PacketSize = 4096;
            csb.MultipleActiveResultSets = false;
            csb.ApplicationName = "CorMine";
            System.Console.WriteLine(csb.ConnectionString);
        }


        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [System.STAThread]
        static void Main()
        {
#if false
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Form1());
#endif

            // TestConnectionString();
            Tests.TestMain();


            System.Console.WriteLine(System.Environment.NewLine);
            System.Console.WriteLine(" --- Press any key to continue --- ");
            System.Console.ReadKey();
        }


    }


}
