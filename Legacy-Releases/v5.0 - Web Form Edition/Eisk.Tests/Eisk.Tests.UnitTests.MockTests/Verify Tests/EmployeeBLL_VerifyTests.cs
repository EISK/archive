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
using Eisk.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Eisk.Tests.UnitTests.MockTests
{
    [TestClass]
    public class EmployeeBLL_VerifyTests
    {
        //a mock database context is required to make a data operation without connecting to database
        protected Mock<DatabaseContext> mockDatabaseConext;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            mockDatabaseConext = new Mock<DatabaseContext>();
        }

        [TestCleanup()]
        public void MyTestCleanUp()
        {
            mockDatabaseConext.Object.Dispose();
        }

        #region Get Method Tests

        [TestMethod]
        public void GetEmployeeByEmployeeId_NonZeroEmployeeIdPassed_ShouldCall_DatabaseContext_Employees_PropertyGet()
        {
            /*The reason to use FakeObjectSet is, CreateNewEmployee method includes query level operation for business logic, we need to use FakeObjectSet. If no query was used we could use IObjectSet mock.*/
            FakeObjectSet<Employee> employees = new FakeObjectSet<Employee>();

            //setting up expectation for the DatabaseContext.Employees property to be called
            mockDatabaseConext.Setup(_db => _db.Employees).Verifiable();

            //an EmployeeDatabaseContext.Employees ObjectSet is required for invoking IObjectSet.AddObject method
            mockDatabaseConext.Setup(_db => _db.Employees).Returns(employees);

            EmployeeBLL employeeBLL = new EmployeeBLL(mockDatabaseConext.Object);

            //calling the method for expected method verification
            employeeBLL.GetEmployeeByEmployeeId(1);

            mockDatabaseConext.Verify();
        }

       #endregion

        #region Create, Update and Delete method tests

        [TestMethod]
        public void CreateNewEmployee_NewEmployeeObjectPassed_ShouldCall_ObjectSet_AddObject_Method()
        {
            /*Creating Mock (and Fake) ObjectSet of Employee entity
            The reason to use Mock is to make ObjectSet available for verification.
            The reason to use FakeObjectSet is, CreateNewEmployee method includes query level operation for business logic, we need to use FakeObjectSet. If no query was used we could use IObjectSet mock.*/
            Mock<FakeObjectSet<Employee>> employees = new Mock<FakeObjectSet<Employee>>();
            employees.Setup(emp => emp.AddObject(It.IsAny<Employee>())).Verifiable();
            mockDatabaseConext.Setup(db => db.SaveChanges()).Returns(1);

            //an EmployeeDatabaseContext.Employees ObjectSet is required for invoking IObjectSet.AddObject method
            mockDatabaseConext.Setup(_db => _db.Employees).Returns(employees.Object);

            EmployeeBLL employeeBLL = new EmployeeBLL(mockDatabaseConext.Object);

            //calling the method for expected method verification
            employeeBLL.CreateNewEmployee(TestDataFactory.CreateNewObjectWithValidNewEmployeeData());

            employees.Verify();
        }

        [TestMethod]
        public void CreateNewEmployee_NewEmployeeObjectPassed_ShouldCall_DatabaseContext_SaveChanges_Method()
        {
            /*The reason to use FakeObjectSet is, CreateNewEmployee method includes query level operation for business logic, we need to use FakeObjectSet. If no query was used we could use IObjectSet mock.*/
            FakeObjectSet<Employee> employees = new FakeObjectSet<Employee>();

            //setting up expectation for the DatabaseContext.SaveChanges method to be called
            mockDatabaseConext.Setup(_db => _db.SaveChanges()).Verifiable();
            //an EmployeeDatabaseContext.Employees ObjectSet is required for invoking IObjectSet.AddObject method
            mockDatabaseConext.Setup(_db => _db.Employees).Returns(employees); 
            mockDatabaseConext.Setup(_db => _db.SaveChanges()).Returns(1);
            

            EmployeeBLL employeeBLL = new EmployeeBLL(mockDatabaseConext.Object);

            //calling the method for expected method verification
            employeeBLL.CreateNewEmployee(TestDataFactory.CreateNewObjectWithValidNewEmployeeData());

            mockDatabaseConext.Verify();
        }

        #endregion
    }
}
