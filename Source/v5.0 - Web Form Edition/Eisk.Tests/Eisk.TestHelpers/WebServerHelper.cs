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
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace Eisk.TestHelpers
{
    
    public sealed class WebServerHelper
    {
        WebServerHelper() { }
        
        public static void StartWebServerIfNotStarted()
        {
            string webServerExePath = (string)ConfigurationManager.AppSettings["WebServerExePath"];
            StartWebServerIfNotStarted(webServerExePath);    
        }

        public static void StartWebServerIfNotStarted(string webServerExePath)
        {
            if (Process.GetProcessesByName("WebDev.WebServer40").Length == 0)
            {
                if (webServerExePath == null)
                    webServerExePath = @"C:\Program Files (x86)\Common Files\microsoft shared\DevServer\10.0\WebDev.WebServer40.exe";

                Process.Start(webServerExePath, GetWebServerArguments());
            }
        }

        public static void StopWebServerIfStarted()
        {
            if (Process.GetProcessesByName("WebDev.WebServer40").Length > 0)
            {
                Process.GetProcessesByName("WebDev.WebServer40")[0].Kill();
            }
        }

        static string GetWebServerArguments()
        {
            string args = String.Format(System.Globalization.CultureInfo.CurrentCulture, "/port:{0} /path:\"{1}\" /vpath:\"{2}\"", GetPort(), GetWebApplicationPath(), GetVPath());
            return args;
        }

        static string GetVPath()
        {
            return "/Eisk.Web";
        }

        static string GetPort()
        {
            return "56180";
        }

        static string GetWebApplicationPath()
        {
            FileInfo f = new FileInfo(@"..\..\..\..\Eisk.Web");
            return f.FullName;
        }
    }

}