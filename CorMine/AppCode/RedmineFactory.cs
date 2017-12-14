
namespace CorMine
{


    public class RedmineFactory
    {


        public static Redmine.Net.Api.RedmineManager CreateInstance()
        {
            /*
            Redmine.Net.Api.RedmineManager rm2 = new Redmine.Net.Api.RedmineManager(
                 "host"
                ,"apikey"
                ,Redmine.Net.Api.MimeFormat.Xml
                ,false // Verify SSL-certificate
                ,null // Proxy
                ,System.Net.SecurityProtocolType.Tls
            );


            Redmine.Net.Api.RedmineManager rm = new Redmine.Net.Api.RedmineManager(
                 "host"
                ,Redmine.Net.Api.MimeFormat.Xml
                ,false // Verify SSL-certificate
                ,null // Proxy
                ,System.Net.SecurityProtocolType.Tls
            );
            */


            string dbUserId = SecretManager.GetSecret<string>("DefaultDbUser");
            string dbPw = SecretManager.GetSecret<string>("DefaultDbPassword");


            Redmine.Net.Api.RedmineManager redmineManager = new Redmine.Net.Api.RedmineManager(
                 // "http://redmine.cor.local"
                 //"http://redmine.cor-management.ch"

                 "https://servicedesk.cor-management.ch/Servicedesk/"
                , SecretManager.GetSecret<string>("RedmineSuperUser")
                , SecretManager.GetSecret<string>("RedmineSuperUserPassword")
                , Redmine.Net.Api.MimeFormat.Xml
                , false // Verify SSL-certificate
                , null // Proxy
                       // ,new System.Net.WebProxy("http://127.0.0.1:80") // http(s)://<IP>:<Port> e.g. http://127.0.0.1:80
                , System.Net.SecurityProtocolType.Tls
            );

            return redmineManager;
        } // End Sub CreateInstance 


    }


}
