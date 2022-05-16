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
using Eisk.BusinessLogicLayer;
using Eisk.BusinessEntities;
using Eisk.TestHelpers;
using System;
using Moq;
using Eisk.DataAccessLayer;

namespace Eisk.Tests.UnitTests.MockTests
{
    [TestClass]
    public class EmployeeBLL_CRUDLogicTests
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

        [TestMethod]
        public void GetEmployeeByEmployeeId_MethodCalledWithEmployeeId_ShouldGetCorrespondingEmployeeInfo()
        {
            //---------------------------------- ARRANGE -------------------------------------
            
            //setting up the in-memory database with required data for test
            FakeObjectSet<Employee> employeeObjectSet = new FakeObjectSet<Employee>();
            Employee employeeOldData = TestDataFactory.CreateNewObjectWithValidExistingEmployeeData();
            employeeObjectSet.AddObject(employeeOldData);
            mockDatabaseConext.Setup(db => db.Employees).Returns(employeeObjectSet);

            EmployeeBLL employeeBLL = new EmployeeBLL(mockDatabaseConext.Object);

            string EXPECTED_ADDRESS = employeeOldData.Address;
            
            //---------------------------------- ACT -------------------------------------

            Employee employeeNewData = employeeBLL.GetEmployeeByEmployeeId(1);

            //---------------------------------- ASSERT -------------------------------------

            string ACTUAL_ADDRESS = employeeNewData.Address;

            Assert.AreEqual(EXPECTED_ADDRESS, ACTUAL_ADDRESS, "Address should be found");
        }

        [TestMethod]
        public void CreateNewEmployee_MethodCalledWithEmployeeId_ShouldRunSuccessfully()
        {
            //setting up the in-memory database with required data for test
            FakeObjectSet<Employee> employeeObjectSet = new FakeObjectSet<Employee>();
            mockDatabaseConext.Setup(db => db.Employees).Returns(employeeObjectSet);
            mockDatabaseConext.Setup(db => db.SaveChanges()).Returns(1);
            EmployeeBLL employeeBLL = new EmployeeBLL(mockDatabaseConext.Object);
            Employee employeeNewData = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();

            employeeBLL.CreateNewEmployee(employeeNewData);

        }
    }
}
