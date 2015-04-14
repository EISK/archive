using System.Web.Mvc;
using System.Text;
using System.Text.RegularExpressions;
using System;

namespace Eisk.Helpers
{
    public static class HtmlConverter
    {
        public static string ConvertTextToPlainHtml(string text)
        {
            text = ConvertTextToNewLine(text);
            text = ConvertTextToLinks(text);

            return text;
        }

        public static string LinkWrapper(string text, string url)
        {
            return "<a target=_blank href=" + url + ">" + text + "</a>";
        }

        public static string ConvertTextToNewLine(string text)
        {
            return text.Replace(Environment.NewLine, "<br/>");
        }
        
        public static string ConvertTextToLinks(string text)
        {
            //Finds URLs with no protocol
            var urlregex = new Regex(@"\b\({0,1}(?<url>(www|ftp)\.[^ ,""\s<)]*)\b",
              RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //Finds URLs with a protocol
            var httpurlregex = new Regex(@"\b\({0,1}(?<url>[^>](http://www\.|http://|https://|ftp://)[^,""\s<)]*)\b",
              RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //Finds email addresses
            var emailregex = new Regex(@"\b(?<mail>[a-zA-Z_0-9.-]+\@[a-zA-Z_0-9.-]+\.\w+)\b",
              RegexOptions.IgnoreCase | RegexOptions.Compiled);
            text = urlregex.Replace(text, " <a href=\"http://${url}\" target=\"_blank\">${url}</a>");
            text = httpurlregex.Replace(text, " <a href=\"${url}\" target=\"_blank\">${url}</a>");
            text = emailregex.Replace(text, "<a href=\"mailto:${mail}\">${mail}</a>");
            return text;
        }
    }
}
