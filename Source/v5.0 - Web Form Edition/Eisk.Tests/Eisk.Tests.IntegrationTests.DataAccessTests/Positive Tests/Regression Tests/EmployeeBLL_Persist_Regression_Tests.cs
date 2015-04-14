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
using Eisk.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eisk.Tests.IntegrationTests.DataAccessTests.PositiveTests.RegressionTests
{
    [TestClass]
    public class EmployeeBLL_Persist_Regression_Tests : DataAccessLayerBaseTest
    {
        [TestMethod]
        public void Given14Employees_WhenANewEmployeeCreatedToDatabase_ShouldHave15Records()
        {
            //---------------------------------- ARRANGE -------------------------------------

            Employee employee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            const int EXPECTED_COUNT = 15;
            
            //---------------------------------- ACT -------------------------------------

            EmployeeBLL.CreateNewEmployee(employee);

            //---------------------------------- ASSERT -------------------------------------

            int ACTUAL_COUNT = EmployeeBLL.GetTotalCountForAllEmployees(string.Empty, 0, 0);
            Assert.AreEqual(EXPECTED_COUNT, ACTUAL_COUNT, "Count doesn't match!");
        }

        [TestMethod]
        public void Given14EmployeesInDb2EmployeesInMemory_WhenTheNewInMemorySupervisorIsAddedToDatabase_ShouldHave16RecordsInDb()
        {
            //---------------------------------- ARRANGE -------------------------------------

            //arranging supervisor data
            Employee supervisorEmployee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();

            //arranging subordinate data
            Employee subordinateEmployee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            subordinateEmployee.Supervisor = supervisorEmployee;

            //arranging count data
            const int EXPECTED_COUNT = 16;

            //---------------------------------- ACT -------------------------------------

            EmployeeBLL.CreateNewEmployee(supervisorEmployee);

            //---------------------------------- ASSERT -------------------------------------

            int ACTUAL_COUNT = EmployeeBLL.GetTotalCountForAllEmployees(string.Empty, 0, 0);
            Assert.AreEqual(EXPECTED_COUNT, ACTUAL_COUNT, "Count doesn't match!");
        }

        [TestMethod]
        public void Given14EmployeesInDb2EmployeesInMemory_WhenTheNewInMemorySubordinateIsAddedToDatabase_ShouldHave16RecordsInDb()
        {
            //---------------------------------- ARRANGE -------------------------------------

            //arranging supervisor data
            Employee supervisorEmployee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();

            //arranging subordinate data
            Employee subordinateEmployee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            subordinateEmployee.Supervisor = supervisorEmployee;

            //arranging count data
            const int EXPECTED_COUNT = 16;

            //---------------------------------- ACT -------------------------------------

            EmployeeBLL.CreateNewEmployee(subordinateEmployee);

            //---------------------------------- ASSERT -------------------------------------

            int ACTUAL_COUNT = EmployeeBLL.GetTotalCountForAllEmployees(string.Empty, 0, 0);
            Assert.AreEqual(EXPECTED_COUNT, ACTUAL_COUNT, "Count doesn't match!");
        }

        [TestMethod]
        public void Given14EmployeesInDb3EmployeesInMemory_WhenTheNewInMemorySupervisorIsAddedToDatabase_ShouldHave17RecordsInDb()
        {
            //---------------------------------- ARRANGE -------------------------------------

            //arranging supervisor data
            Employee supervisorEmployee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();

            //arranging subordinate data
            Employee subordinateEmployee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            subordinateEmployee.Supervisor = supervisorEmployee;

            Employee subordinateEmployee2 = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            subordinateEmployee2.Supervisor = supervisorEmployee;

            //arranging count data
            const int EXPECTED_COUNT = 17;

            //---------------------------------- ACT -------------------------------------

            EmployeeBLL.CreateNewEmployee(supervisorEmployee);

            //---------------------------------- ASSERT -------------------------------------

            int ACTUAL_COUNT = EmployeeBLL.GetTotalCountForAllEmployees(string.Empty, 0, 0);
            Assert.AreEqual(EXPECTED_COUNT, ACTUAL_COUNT, "Count doesn't match!");
        }

        [TestMethod]
        public void Given14EmployeesInDb3EmployeesInMemory_WhenTheFirstNewInMemorySubordinateIsAddedToDatabase_ShouldHave17RecordsInDb()
        {
            //---------------------------------- ARRANGE -------------------------------------

            //arranging supervisor data
            Employee supervisorEmployee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();

            //arranging subordinate data
            Employee subordinateEmployee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            subordinateEmployee.Supervisor = supervisorEmployee;

            Employee subordinateEmployee2 = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            subordinateEmployee2.Supervisor = supervisorEmployee;

            //arranging count data
            const int EXPECTED_COUNT = 17;

            //---------------------------------- ACT -------------------------------------

            EmployeeBLL.CreateNewEmployee(subordinateEmployee);

            //---------------------------------- ASSERT -------------------------------------

            int ACTUAL_COUNT = EmployeeBLL.GetTotalCountForAllEmployees(string.Empty, 0, 0);
            Assert.AreEqual(EXPECTED_COUNT, ACTUAL_COUNT, "Count doesn't match!");
        }


        [TestMethod]
        public void Given14EmployeesInDb3EmployeesInMemory_WhenTheSecondNewInMemorySubordinateIsAddedToDatabase_ShouldHave17RecordsInDb()
        {
            //---------------------------------- ARRANGE -------------------------------------

            //arranging supervisor data
            Employee supervisorEmployee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();

            //arranging subordinate data
            Employee subordinateEmployee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            subordinateEmployee.Supervisor = supervisorEmployee;

            Employee subordinateEmployee2 = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            subordinateEmployee2.Supervisor = supervisorEmployee;

            //arranging count data
            const int EXPECTED_COUNT = 17;

            //---------------------------------- ACT -------------------------------------

            EmployeeBLL.CreateNewEmployee(subordinateEmployee2);

            //---------------------------------- ASSERT -------------------------------------

            int ACTUAL_COUNT = EmployeeBLL.GetTotalCountForAllEmployees(string.Empty, 0, 0);
            Assert.AreEqual(EXPECTED_COUNT, ACTUAL_COUNT, "Count doesn't match!");
        }

        //----------------------------------------------------------

        [TestMethod]
        public void Given14EmployeesInDb1NewInMemorySubordinateEmployee_WhenSupervisorIsUpdatedToDatabase_ShouldHave15RecordsInDb()
        {
            //---------------------------------- ARRANGE -------------------------------------

            //arranging supervisor data
            Employee supervisorEmployee = EmployeeBLL.GetEmployeeByEmployeeId(1);
            
            //arranging subordinate data
            Employee subordinateEmployee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            subordinateEmployee.Supervisor = supervisorEmployee;

            //arranging count data
            const int EXPECTED_COUNT = 15;
            
            //---------------------------------- ACT -------------------------------------

            EmployeeBLL.UpdateEmployee(supervisorEmployee);

            //---------------------------------- ASSERT -------------------------------------

            int ACTUAL_COUNT = EmployeeBLL.GetTotalCountForAllEmployees(string.Empty, 0, 0);
            Assert.AreEqual(EXPECTED_COUNT, ACTUAL_COUNT, "Count doesn't match!");
        }

        [TestMethod]
        public void Given14EmployeesInDb1NewInMemorySubordinateEmployee_WhenInMemorySubordinateIsCreatedToDatabase_ShouldHave15RecordsInDb()
        {
            //---------------------------------- ARRANGE -------------------------------------

            //arranging supervisor data
            Employee supervisorEmployee = EmployeeBLL.GetEmployeeByEmployeeId(1);

            //arranging subordinate data
            Employee subordinateEmployee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            subordinateEmployee.Supervisor = supervisorEmployee;

            //arranging count data
            const int EXPECTED_COUNT = 15;

            //---------------------------------- ACT -------------------------------------

            EmployeeBLL.CreateNewEmployee(subordinateEmployee);

            //---------------------------------- ASSERT -------------------------------------

            int ACTUAL_COUNT = EmployeeBLL.GetTotalCountForAllEmployees(string.Empty, 0, 0);
            Assert.AreEqual(EXPECTED_COUNT, ACTUAL_COUNT, "Count doesn't match!");
        }

        [TestMethod]
        public void Given14EmployeesInDb_WhenSupervisorEmployeeIsUpdatedToDatabase_ShouldHave14RecordsInDb()
        {
            //---------------------------------- ARRANGE -------------------------------------

            //arranging supervisor data
            Employee supervisorEmployee = EmployeeBLL.GetEmployeeByEmployeeId(1);

            //arranging subordinate data
            Employee subordinateEmployee = EmployeeBLL.GetEmployeeByEmployeeId(2);
            subordinateEmployee.Supervisor = supervisorEmployee;
            subordinateEmployee.Country = supervisorEmployee.Country;

            //arranging count data
            const int EXPECTED_COUNT = 14;

            //---------------------------------- ACT -------------------------------------

            EmployeeBLL.UpdateEmployee(supervisorEmployee);

            //---------------------------------- ASSERT -------------------------------------

            int ACTUAL_COUNT = EmployeeBLL.GetTotalCountForAllEmployees(string.Empty, 0, 0);
            Assert.AreEqual(EXPECTED_COUNT, ACTUAL_COUNT, "Count doesn't match!");
        }

        [TestMethod]
        public void Given14EmployeesInDb_WhenSubordinateEmployeeIsUpdatedToDatabase_ShouldHave14RecordsInDb()
        {
            //---------------------------------- ARRANGE -------------------------------------

            //arranging supervisor data
            Employee supervisorEmployee = EmployeeBLL.GetEmployeeByEmployeeId(1);

            //arranging subordinate data
            Employee subordinateEmployee = EmployeeBLL.GetEmployeeByEmployeeId(2);
            subordinateEmployee.Supervisor = supervisorEmployee;
            subordinateEmployee.Country = supervisorEmployee.Country;

            //arranging count data
            const int EXPECTED_COUNT = 14;

            //---------------------------------- ACT -------------------------------------

            EmployeeBLL.UpdateEmployee(subordinateEmployee);

            //---------------------------------- ASSERT -------------------------------------

            int ACTUAL_COUNT = EmployeeBLL.GetTotalCountForAllEmployees(string.Empty, 0, 0);
            Assert.AreEqual(EXPECTED_COUNT, ACTUAL_COUNT, "Count doesn't match!");
        }
        
    }
}
