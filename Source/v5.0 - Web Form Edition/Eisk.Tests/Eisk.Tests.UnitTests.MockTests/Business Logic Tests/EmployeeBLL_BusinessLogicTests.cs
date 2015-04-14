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
using Eisk.DataAccessLayer;
using Eisk.Helpers;
using Eisk.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace Eisk.Tests.UnitTests.MockTests
{
    [TestClass]
    public class EmployeeBLL_BusinessLogicTests
    {
        //a mock database context is required to make a data operation without connecting to database
        protected Mock<DatabaseContext> mockDatabaseConext;
        protected EmployeeBLL employeeBLL;
        protected FakeObjectSet<Employee> employeeObjectSet;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            employeeObjectSet = new FakeObjectSet<Employee>();
            mockDatabaseConext = new Mock<DatabaseContext>();
            employeeBLL = new EmployeeBLL(mockDatabaseConext.Object);
        }

        [TestCleanup()]
        public void MyTestCleanUp()
        {
            mockDatabaseConext.Object.Dispose();
            //employeeBLL.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleViolationOnDbAccessException), "Exception not thrown as expected.")]
        public void CreateNewEmployee_SupervisorsCountryIsNotSame_ShouldThrowException()
        {
            //---------------------------------- ARRANGE -------------------------------------

            const string SUPERVISOR_COUNTRY = "USA";
            const string EMPLOYEE_COUNTRY = "UK";

            //creating sample data for other employee, that would contain the different COUNTRY of the new employee
            Employee supervisorEmployee = TestDataFactory.CreateNewObjectWithValidExistingEmployeeData();
            supervisorEmployee.Country = SUPERVISOR_COUNTRY;

            //populating sample data to ObjectSet container that would be considered as the data source in mock database for employee entities
            employeeObjectSet = new FakeObjectSet<Employee>();
            employeeObjectSet.AddObject(supervisorEmployee);

            //setting up the mock database with sample object
            mockDatabaseConext.Setup(db => db.Employees).Returns(employeeObjectSet);

            //creating sample data for new employee, that would contain the different COUNTRY of another employee loaded in mock database
            Employee newEmployee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            newEmployee.Country = EMPLOYEE_COUNTRY;
            newEmployee.Supervisor = supervisorEmployee;

            //---------------------------------- ACT -------------------------------------

            //perform the operation that is under test
            employeeBLL.CreateNewEmployee(newEmployee);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleViolationOnDbAccessException), "Exception not thrown as expected.")]
        public void UpdateEmployee_SupervisorsCountryIsNotSame_ShouldThrowException()
        {
            //---------------------------------- ARRANGE -------------------------------------
            
            const string SUPERVISOR_COUNTRY = "USA";
            const string SUBORDINATE_DIFFERENT_COUNTRY = "UK";

            //creating sample data for other employee, that would contain the different COUNTRY of the employee
            Employee supervisorEmployee = TestDataFactory.CreateNewObjectWithValidExistingEmployeeData();
            supervisorEmployee.EmployeeId = 1;
            supervisorEmployee.Country = SUPERVISOR_COUNTRY;

            Employee subordinateEmployee = TestDataFactory.CreateNewObjectWithValidExistingEmployeeData();
            subordinateEmployee.EmployeeId = 2;

            //populating sample data to ObjectSet container that would be considered as the data source in mock database for employee entities
            employeeObjectSet = new FakeObjectSet<Employee>();
            employeeObjectSet.AddObject(supervisorEmployee);
            employeeObjectSet.AddObject(subordinateEmployee);

            //setting up the mock database with sample object
            mockDatabaseConext.Setup(db => db.Employees).Returns(employeeObjectSet);

            //updating sample data for subordinate employee, that would contain the different COUNTRY of another employee loaded in mock database
            Employee subordinateEmployeeUpdated = TestDataFactory.CreateNewObjectWithValidExistingEmployeeData();
            subordinateEmployeeUpdated.EmployeeId = 2;
            subordinateEmployeeUpdated.Supervisor = supervisorEmployee;
            subordinateEmployeeUpdated.Country = SUBORDINATE_DIFFERENT_COUNTRY;

            //---------------------------------- ACT -------------------------------------

            //perform the operation that is under test
            employeeBLL.UpdateEmployee(subordinateEmployeeUpdated);
        }
    }
}
