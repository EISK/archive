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


using Eisk.BusinessEntities;
using Eisk.Helpers;
using Eisk.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eisk.Tests.UnitTests.NegativeTests
{
    [TestClass]
    public class Employee_Invalid_Empty_Value_Validation_Tests
    {
        [TestMethod]
        [ExpectedException(typeof(EmptyValueNotAllowedException), "Passing empty 'LastName' is invalid. Method should throw exception.")]
        public void LastName_EmptyLastNameAssigned_ShouldThrowException()
        {
            //Arrange
            Employee employee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            const string INVALID_VALUE_AS_EMPTY = "";

            //Act
            employee.LastName = INVALID_VALUE_AS_EMPTY;
        }

    }
}
