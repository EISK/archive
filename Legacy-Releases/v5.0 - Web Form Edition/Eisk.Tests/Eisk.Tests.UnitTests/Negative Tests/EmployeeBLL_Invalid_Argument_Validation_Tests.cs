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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eisk.TestHelpers;
using Eisk.BusinessEntities;

namespace Eisk.Tests.UnitTests.NegativeTests
{
    [TestClass]
    public class EmployeeBLL_Invalid_Argument_Validation_Tests : TestBusinessLogicLayerFactory
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Passing null 'Employee' object is invalid. Method didnot throw exception as expected.")]
        public void CreateNewEmployee_NullEmployeeToBePassedAsArgument_ShouldThrowException()
        {
            //Arrange
            Employee NULL_EMPLOYEE_AS_INVALID_VALUE = null;

            //Act
            EmployeeBLL.CreateNewEmployee(NULL_EMPLOYEE_AS_INVALID_VALUE);
        }
    }
}

