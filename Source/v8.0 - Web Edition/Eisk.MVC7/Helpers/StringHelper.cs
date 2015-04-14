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
using System.Web.Mvc;
using System.Text;

namespace Eisk.Helpers
{
    public static class StringHelper
    {
        public static string ConnectStrings(string connector, params string[] items)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    output.Append(items[i]);

                    //if the current item is not the last item
                    if (i < items.Length - 1)
                        output.Append(connector);
                }
            }

            if (output.ToString().EndsWith(connector))
                output.Remove(output.ToString().Length - connector.Length, connector.Length);

            return output.ToString();
        }

    }
}
