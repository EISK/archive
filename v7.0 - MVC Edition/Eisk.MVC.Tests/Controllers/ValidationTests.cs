using System.ComponentModel.DataAnnotations;
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
using Eisk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System;
using Eisk.Helpers;

namespace Eisk.Tests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void Employee_model_set_with_Ivalidable_objet()
        {
            // Arrange
            var propertyInfo = typeof(Employee).GetProperty("FirstName");

            // Act
            var attribute = propertyInfo.GetCustomAttributes(typeof(RequiredAttribute), false);

            // Assert
            Assert.IsNotNull(attribute);
        }
        [TestMethod]
        public void Test_Copy()
        {
            Employee emp = TestDataHelper.CreateEmployeeWithValidData();
            Type type = emp.GetType();
            PropertyInfo[] myObjectFields = type.GetProperties(
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo fi in myObjectFields)
            {
                Console.WriteLine(fi.ToString());
            }
        }

        private static void UpdateForType(Type type, Object source, Object destination)
        {
            FieldInfo[] myObjectFields = type.GetFields(
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            foreach (FieldInfo fi in myObjectFields)
            {
                fi.SetValue(destination, fi.GetValue(source));
            }
        }

        //[TestMethod]
        //public void TestWebApi()
        //{
        //    //perform call to authentication api for validation
        //    string apiAddress = "http://localhost:2468/api/AuthenticationApi/GetAll/";

        //    JsonArray responseData = HttpClientHelper.ExtractContent<JsonArray>(apiAddress);
        //    Assert.IsNotNull(responseData);
        //}

    }
}
