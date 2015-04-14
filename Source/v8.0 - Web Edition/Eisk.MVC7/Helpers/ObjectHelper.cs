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

using System.Reflection;
using System;
using System.Linq.Expressions;

namespace Eisk.Helpers
{
    public static class ObjectHelper
    {
        public static string GetName<T>(Expression<Func<T>> memberExpression)
        {
            return (memberExpression.Body as MemberExpression).Member.Name;
        }

        public static void CopyPropertiesValueFromBaseType<Entity>(Entity baseSource, Entity destinationChild)
        {
            Type type = typeof(Entity);

            PropertyInfo[] myObjectFields = type.GetProperties(
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo fi in myObjectFields)
            {
                fi.SetValue(destinationChild, fi.GetValue(baseSource, null), null);
            }
        }
    }
}
