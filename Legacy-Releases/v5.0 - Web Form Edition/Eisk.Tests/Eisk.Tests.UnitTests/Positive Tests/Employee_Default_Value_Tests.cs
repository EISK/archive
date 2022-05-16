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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eisk.TestHelpers;
using Eisk.BusinessEntities;

namespace Eisk.Tests.UnitTests.PositiveTests
{
    [TestClass]
    public class Employee_Default_Value_Tests
    {
        [TestMethod]
        public void PhotoPath_NullPhotoPathAssigned_ShouldGetDefaultValue()
        {
            //Arrange
            Employee employee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            const string EXPECTED_DEFAULT_VALUE = "n/a";
            
            //Act
            employee.Extension = null;
            
            //Assert
            string ACTUAL_DEFAULT_VALUE = employee.Extension;
            Assert.AreEqual(EXPECTED_DEFAULT_VALUE, ACTUAL_DEFAULT_VALUE, "Default value not found!");
        }
    }
}
