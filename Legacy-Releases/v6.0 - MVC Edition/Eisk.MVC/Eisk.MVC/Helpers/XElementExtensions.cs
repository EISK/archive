/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2013
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/

using System;
using System.Xml.Linq;

namespace Eisk.Helpers
{
    public static class XElementExtensions
    {
        public static string GetStringValue(this XElement element, string field)
        {
            return (element.Element(field) == null) ? null : element.Element(field).Value;
        }

        public static DateTime? GetDateTimeValue(this XElement element, string field)
        {
            if (element.Element(field) == null)
                return null;

            DateTime result;

            DateTime.TryParse(element.Element(field).Value, out result);

            return result;
        }

        public static int? GetIntValue(this XElement element, string field)
        {
            if (element.Element(field) == null)
                return null;

            int result;

            int.TryParse(element.Element(field).Value, out result);

            return result;
        }

        public static byte[] GetByteArrayValue(this XElement element, string field)
        {
            return null;
        }

    }
}