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

namespace Eisk.Tests.IntegrationTests.DataAccessTests.PositiveTests.RegressionTests
{
    [TestClass]
    public class EmployeeBLL_Create_Valid_DataField_Persist_Tests : DataAccessLayerBaseTest
    {
        [TestMethod()]
        public void LastName_ValidValueToBeInsertedToDatabase_ShouldReturnSameValueFromDatabase()
        {
            //---------------------------------- ARRANGE -------------------------------------

            Employee newEmployeeObjectWithValidSampleData = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            const string EXPECTED_LAST_NAME = "Doe";
            newEmployeeObjectWithValidSampleData.LastName = EXPECTED_LAST_NAME;

            //---------------------------------- ACT -------------------------------------
            
            int newEmployeeId = EmployeeBLL.CreateNewEmployee(newEmployeeObjectWithValidSampleData);
            
            Employee insertedEmployee = EmployeeBLL.GetEmployeeByEmployeeId(newEmployeeId);
            string ACTUAL_LAST_NAME = insertedEmployee.LastName;

            Assert.AreEqual(EXPECTED_LAST_NAME, ACTUAL_LAST_NAME, "value was NOT inserted successfully.");
        }

        [TestMethod()]
        public void FirstName_ValidValueToBeInsertedToDatabase_ShouldReturnSameValueFromDatabase()
        {
            //---------------------------------- ARRANGE -------------------------------------

            Employee newEmployeeObjectWithValidSampleData = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            const string EXPECTED_FIRST_NAME = "John";
            newEmployeeObjectWithValidSampleData.FirstName = EXPECTED_FIRST_NAME;
            
            //---------------------------------- ACT -------------------------------------
            
            int newEmployeeId = EmployeeBLL.CreateNewEmployee(newEmployeeObjectWithValidSampleData);
            
            Employee insertedEmployee = EmployeeBLL.GetEmployeeByEmployeeId(newEmployeeId);
            string ACTUAL_FIRST_NAME = insertedEmployee.FirstName;

            //---------------------------------- ASSERT -------------------------------------

            Assert.AreEqual(EXPECTED_FIRST_NAME, ACTUAL_FIRST_NAME, "value was NOT inserted successfully.");
        }

    }
}
