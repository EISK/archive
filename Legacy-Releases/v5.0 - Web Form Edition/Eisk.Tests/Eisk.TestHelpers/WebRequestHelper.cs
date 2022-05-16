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
using System.IO;
using System.Net;
using System.Globalization;

namespace Eisk.TestHelpers
{

    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// </summary>
    public enum RequiredAccess { Public, Member, Admin }

    /// <summary>
    /// The TestHelperRoot.WebRequestHelper class provides a useful technique to access the pages programmatically that requires authentication.
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// </summary>
    public sealed class WebRequestHelper
    {
        public WebRequestHelper()
        {
        }

        public WebRequestHelper(string loginUrl, string userName, string password) 
        {
            _logOnUrl = new Uri(loginUrl);
            _userName = userName;
            _password = password;
        }

        Uri _logOnUrl = null;
        string _userName = string.Empty;
        string _password = string.Empty;

        public HttpStatusCode GetWebpageStatusCode(Uri url, RequiredAccess requiredAccess)
        {
            HttpWebRequest req = ((HttpWebRequest)(WebRequest.Create(url)));
            req.Proxy = new WebProxy();
            req.Proxy.Credentials = CredentialCache.DefaultCredentials;

            if (requiredAccess == RequiredAccess.Member)
                req.CookieContainer = GetSecurityCookie(false);
            else if (requiredAccess == RequiredAccess.Admin)
                req.CookieContainer = GetSecurityCookie(true);

            HttpWebResponse resp = null;
            try
            {
                resp = ((HttpWebResponse)(req.GetResponse()));
                return resp.StatusCode;

                //if (resp.StatusCode == HttpStatusCode.OK)
                //{
                //    if (url.ToString().ToLower(CultureInfo.CurrentCulture).IndexOf("redirect", StringComparison.CurrentCulture) == -1 && 
                //        url.ToString().ToLower(CultureInfo.CurrentCulture).IndexOf(resp.ResponseUri.AbsolutePath.ToLower(CultureInfo.CurrentCulture), StringComparison.CurrentCulture) == -1)
                //    {
                //        return HttpStatusCode.NotFound;
                //    }
                //}
            }
            catch (System.Exception ex)
            {
                while (!(ex == null))
                {
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine("INNER EXCEPTION");
                    ex = ex.InnerException;
                }

                throw;
            }
            finally
            {
                if (!(resp == null))
                {
                    resp.Close();
                }
            }
            return resp.StatusCode;
        }

        public CookieContainer GetSecurityCookie(bool isAdminCookieRequired)
        {
            // first, request the login form to get the viewstate value
            Uri uri = _logOnUrl;
            
            HttpWebRequest webRequest = ((HttpWebRequest)WebRequest.Create(uri));
            StreamReader responseReader = new StreamReader(
                  webRequest.GetResponse().GetResponseStream()
               );
            string responseData = responseReader.ReadToEnd();
            responseReader.Close();

            // extract the viewstate value and build out POST data
            string viewState = ExtractViewState(responseData);

            string postData = string.Empty;

            if (isAdminCookieRequired)
            {
                postData = String.Format(System.Globalization.CultureInfo.CurrentCulture,
                   "__VIEWSTATE={0}&BodyContentPlaceholder_txtUserName={1}&BodyContentPlaceholder_txtPassword={2}&BodyContentPlaceholder_buttonAdminLogOn=admin log in",
                   viewState, _userName, _password
                );
            }
            else
            {
                postData = String.Format(System.Globalization.CultureInfo.CurrentCulture,
                       "__VIEWSTATE={0}&BodyContentPlaceholder_txtUserName={1}&BodyContentPlaceholder_txtPassword={2}&BodyContentPlaceholder_buttonLogOn=Log in as Member",
                       viewState, _userName, _password
                    );
            }

            // have a cookie container ready to receive the forms auth cookie
            CookieContainer cookies = new CookieContainer();

            // now post to the login form
            webRequest = WebRequest.Create(uri) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.CookieContainer = cookies;

            // write the form values into the request message
            StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
            requestWriter.Write(postData);
            requestWriter.Close();

            // we don't need the contents of the response, just the cookie it issues
            webRequest.GetResponse().Close();

            //return the cookie
            return cookies;
        }

        private string ExtractViewState(string s)
        {
            string viewStateNameDelimiter = "__VIEWSTATE";
            string valueDelimiter = "value=\"";

            int viewStateNamePosition = s.IndexOf(viewStateNameDelimiter, StringComparison.CurrentCulture);
            int viewStateValuePosition = s.IndexOf(
                  valueDelimiter, viewStateNamePosition, StringComparison.CurrentCulture
               );

            int viewStateStartPosition = viewStateValuePosition +
                                         valueDelimiter.Length;
            int viewStateEndPosition = s.IndexOf("\"", viewStateStartPosition, StringComparison.CurrentCulture);
            
            return null;
            //return HttpUtility.UrlEncodeUnicode(
            //         s.Substring(
            //            viewStateStartPosition,
            //            viewStateEndPosition - viewStateStartPosition
            //         )
            //      );
        }
    }
}