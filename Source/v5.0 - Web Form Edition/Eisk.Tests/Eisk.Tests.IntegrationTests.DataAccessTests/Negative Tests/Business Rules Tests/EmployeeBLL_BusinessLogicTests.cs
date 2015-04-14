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
using Eisk.BusinessLogicLayer;
using Eisk.Helpers;
using Eisk.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Eisk.Tests.IntegrationTests.DataAccessTests.NegativeTests
{
    [TestClass]
    public class EmployeeBLL_BusinessLogicTests:DataAccessLayerBaseTest
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessRuleViolationOnDbAccessException), "Exception not thrown as expected.")]
        public void CreateNewEmployee_SupervisorsCountryIsNotSame_ShouldThrowException()
        {
            //---------------------------------- ARRANGE -------------------------------------

            const string SUPERVISOR_COUNTRY = "USA";
            const string SUBORDINATE_DIFFERENT_COUNTRY = "Bangladesh";

            //arranging supervisor data
            Employee supervisorEmployee = EmployeeBLL.GetEmployeeByEmployeeId(1);
            supervisorEmployee.Country = SUPERVISOR_COUNTRY;

            //arranging subordinate data
            Employee subordinateEmployee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            subordinateEmployee.Country = SUBORDINATE_DIFFERENT_COUNTRY;
            subordinateEmployee.Supervisor = supervisorEmployee;

            //---------------------------------- ACT -------------------------------------

            //perform the operation that is under test
            EmployeeBLL.CreateNewEmployee(subordinateEmployee);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleViolationOnDbAccessException), "Exception not thrown as expected.")]
        public void UpdateEmployee_SupervisorsCountryIsNotSame_ShouldThrowException()
        {
            //---------------------------------- ARRANGE -------------------------------------
            
            const string SUPERVISOR_COUNTRY = "USA";
            const string SUBORDINATE_DIFFERENT_COUNTRY = "UK";
            
            //arranging supervisor data
            Employee supervisorEmployee = EmployeeBLL.GetEmployeeByEmployeeId(1);
            supervisorEmployee.Country = SUPERVISOR_COUNTRY;

            //arranging subordinate data
            Employee subordinateEmployee = EmployeeBLL.GetEmployeeByEmployeeId(3);
            subordinateEmployee.Country = SUBORDINATE_DIFFERENT_COUNTRY;
            subordinateEmployee.Supervisor = supervisorEmployee;
            
            //---------------------------------- ACT -------------------------------------

            //perform the operation that is under test
            EmployeeBLL.UpdateEmployee(subordinateEmployee);
        }
    }
}
