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

using Eisk.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eisk.Tests.IntegrationTests.DataAccessTests.PositiveTests
{
    [TestClass]
    public class EmployeeBLL_Method_Smoke_Tests : DataAccessLayerBaseTest
    {
        [TestMethod()]
        public void CreateNewEmployee_ValidNewEmployeeObjectPassed_ShouldReturnNonzero()
        {
            //---------------------------------- ARRANGE -------------------------------------

            const int INITIAL_NO_EMPLOYEE_STATE = 0;
            
            //---------------------------------- ACT -------------------------------------

            int NEW_EMPLOYEE_ID = EmployeeBLL.CreateNewEmployee(TestDataFactory.CreateNewObjectWithValidNewEmployeeData());

            //---------------------------------- ASSERT -------------------------------------

            Assert.AreNotEqual(INITIAL_NO_EMPLOYEE_STATE, NEW_EMPLOYEE_ID, "Employee was not created.");
        }

        [TestMethod()]
        public void GetTotalCountForAllEmployees_MethodCalled_ShouldReturnTotalCountOfEmployeeRecords()
        {
            //---------------------------------- ARRANGE -------------------------------------

            const int EXPECTED_COUNT = 14;
            
            //---------------------------------- ACT -------------------------------------

            int ACTUAL_COUNT = EmployeeBLL.GetTotalCountForAllEmployees(string.Empty, 0, 0);
            
            //---------------------------------- ASSERT -------------------------------------

            Assert.AreEqual(EXPECTED_COUNT, ACTUAL_COUNT, "Count doesn't match!");
        }
    }
}
