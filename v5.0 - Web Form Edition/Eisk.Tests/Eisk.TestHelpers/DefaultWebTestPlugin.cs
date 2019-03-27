/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2011
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/

using System;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;
using Eisk.Helpers;
using Microsoft.VisualStudio.TestTools.WebTesting;

namespace Eisk.TestHelpers
{
    public class DefaultWebTestPlugin : WebTestPlugin
    {
        public override void PostWebTest(object sender, PostWebTestEventArgs e)
        {
            //MessageBox.Show("Web Test Ending ...");
        }

        public override void PreWebTest(object sender, PreWebTestEventArgs e)
        {
            //loading the settings files
            
            WebTestSettings webTestSettings = new WebTestSettings();
            webTestSettings.ReadConfig("WebTestSettings.xml");

            //startig the web server
            WebServerHelper.StartWebServerIfNotStarted(webTestSettings.WebServerExePath);
            

            //setting up set-up data
            SqlClientScriptRunner.RunScript(webTestSettings.SqlConnectionString, @"..\..\..\..\Eisk.Database\Basic Scripts\Schema\Create-Schema.sql");
            SqlClientScriptRunner.RunScript(webTestSettings.SqlConnectionString, @"..\..\..\..\Eisk.Database\Basic Scripts\Data\Create-Data.sql");
            
            //message
            
            //MessageBox.Show("Web Test Starting ...");
            
        }
    }

    public class SqlClientScriptRunner
    {
        public static void RunScript(string connectionString, string scriptPath)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = System.Data.CommandType.Text;
            sqlCmd.CommandText = Filer.ReadFromFile(scriptPath);
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                sqlCmd.ExecuteNonQuery();
            }
        }
    }

    [Serializable]
    public class WebTestSettings
    {

        public string SqlConnectionString { get; set; }
        public string WebServerExePath { get; set; }

        //internal void SaveConfig(string ConfigFilePath)
        //{
        //    StreamWriter writer = new StreamWriter(ConfigFilePath);
        //    XmlSerializer serializer = new XmlSerializer(typeof(WebTestSettings));
        //    serializer.Serialize(writer, this);
        //    writer.Close();
        //}

        internal void ReadConfig(string ConfigFilePath)
        {

            StreamReader reader = new StreamReader(ConfigFilePath);
            XmlSerializer serializer = new XmlSerializer(typeof(WebTestSettings));
            WebTestSettings readSettings = (WebTestSettings)serializer.Deserialize(reader);
            
            this.SqlConnectionString = readSettings.SqlConnectionString;
            this.WebServerExePath = readSettings.WebServerExePath;

            reader.Close();

        }
    }
}