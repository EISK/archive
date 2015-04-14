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
    /// <summary>
    /// Each test class in regression test are sanity test for each CRUD method.
    /// Considers the data fields of Employee data container, for which 'allow null' is set.
    /// </summary>
    [TestClass]
    public class EmployeeBLL_Create_Null_DataField_Persist_Tests : DataAccessLayerBaseTest
    {
        [TestMethod()]
        public void Title_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //---------------------------------- ARRANGE -------------------------------------

            Employee newEmployeeObjectWithValidSampleData = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            const string EXPECTED_TITLE = null;
            newEmployeeObjectWithValidSampleData.Title = EXPECTED_TITLE;

            //---------------------------------- ACT -------------------------------------
                        
            int newEmployeeId = EmployeeBLL.CreateNewEmployee(newEmployeeObjectWithValidSampleData);

            //---------------------------------- ASSERT -------------------------------------
            
            Employee insertedEmployee = EmployeeBLL.GetEmployeeByEmployeeId(newEmployeeId);
            string ACTUAL_TITLE = insertedEmployee.Title;
                        
            Assert.AreEqual(EXPECTED_TITLE, ACTUAL_TITLE, "Title was not saved with null value.");
        }

        [TestMethod()]
        public void TitleOfCourtecy_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //---------------------------------- ARRANGE -------------------------------------

            Employee newEmployeeObjectWithValidSampleData = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            const string EXPECTED_TITLE_OF_COURTECY = null;
            newEmployeeObjectWithValidSampleData.TitleOfCourtesy = EXPECTED_TITLE_OF_COURTECY;

            //---------------------------------- ACT -------------------------------------

            int newEmployeeId = EmployeeBLL.CreateNewEmployee(newEmployeeObjectWithValidSampleData);

            //---------------------------------- ASSERT -------------------------------------

            Employee insertedEmployee = EmployeeBLL.GetEmployeeByEmployeeId(newEmployeeId);
            string ACTUAL_TITLE_OF_COURTECY = insertedEmployee.TitleOfCourtesy;

            Assert.AreEqual(EXPECTED_TITLE_OF_COURTECY, ACTUAL_TITLE_OF_COURTECY, "Title of Courtecy was not saved with null value.");
        }

        [TestMethod()]
        public void BirthDate_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //---------------------------------- ARRANGE -------------------------------------

            Employee newEmployeeObjectWithValidSampleData = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            DateTime? EXPECTED_BIRTH_DATE = null;
            newEmployeeObjectWithValidSampleData.BirthDate = EXPECTED_BIRTH_DATE;

            //---------------------------------- ACT -------------------------------------
            
            int newEmployeeId = EmployeeBLL.CreateNewEmployee(newEmployeeObjectWithValidSampleData);

            //---------------------------------- ASSERT -------------------------------------
            
            Employee insertedEmployee = EmployeeBLL.GetEmployeeByEmployeeId(newEmployeeId);
            DateTime? ACTUAL_BIRTH_DATE = insertedEmployee.BirthDate;

            Assert.AreEqual(EXPECTED_BIRTH_DATE, ACTUAL_BIRTH_DATE, "BirthDate was not saved with null value.");
        }

        [TestMethod()]
        public void City_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //---------------------------------- ARRANGE -------------------------------------
            
            Employee newEmployeeObjectWithValidSampleData = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            const string EXPECTED_CITY = null;
            newEmployeeObjectWithValidSampleData.City = EXPECTED_CITY;

            //---------------------------------- ACT -------------------------------------
            
            int newEmployeeId = EmployeeBLL.CreateNewEmployee(newEmployeeObjectWithValidSampleData);
            Employee insertedEmployee = EmployeeBLL.GetEmployeeByEmployeeId(newEmployeeId);
            string ACTUAL_CITY = insertedEmployee.City;

            //---------------------------------- ASSERT -------------------------------------
       
            Assert.AreEqual(EXPECTED_CITY, ACTUAL_CITY, "City was not saved with null value.");
        }

        [TestMethod()]
        public void Region_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //---------------------------------- ARRANGE -------------------------------------

            Employee newEmployeeObjectWithValidSampleData = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            const string EXPECTED_REGION = null;
            newEmployeeObjectWithValidSampleData.Region = EXPECTED_REGION;

            //---------------------------------- ACT -------------------------------------

            int newEmployeeId = EmployeeBLL.CreateNewEmployee(newEmployeeObjectWithValidSampleData);

            //---------------------------------- ASSERT -------------------------------------

            Employee insertedEmployee = EmployeeBLL.GetEmployeeByEmployeeId(newEmployeeId);
            string ACTUAL_REGION = insertedEmployee.Region;
                        
            Assert.AreEqual(EXPECTED_REGION, ACTUAL_REGION, "Region was not saved with null value.");
        }

        [TestMethod()]
        public void PostalCode_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //---------------------------------- ARRANGE -------------------------------------

            Employee newEmployeeObjectWithValidSampleData = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            const string EXPECTED_POSTALCODE = null;
            newEmployeeObjectWithValidSampleData.PostalCode = EXPECTED_POSTALCODE;

            //---------------------------------- ACT -------------------------------------
            
            int newEmployeeId = EmployeeBLL.CreateNewEmployee(newEmployeeObjectWithValidSampleData);

            //---------------------------------- ASSERT -------------------------------------

            Employee insertedEmployee = EmployeeBLL.GetEmployeeByEmployeeId(newEmployeeId);
            string ACTUAL_POSTALCODE = insertedEmployee.PostalCode;

            Assert.AreEqual(EXPECTED_POSTALCODE, ACTUAL_POSTALCODE, "PostalCode was not saved with null value.");
        }

        [TestMethod()]
        public void Extension_NullValueToBeInsertedToDatabase_ShouldReturnDefaultValueFromDatabase()
        {
            //---------------------------------- ARRANGE -------------------------------------

            Employee newEmployeeObjectWithValidSampleData = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            const string EXPECTED_EXTENSION = "n/a";
            newEmployeeObjectWithValidSampleData.Extension = EXPECTED_EXTENSION;

            //---------------------------------- ACT -------------------------------------
            
            int newEmployeeId = EmployeeBLL.CreateNewEmployee(newEmployeeObjectWithValidSampleData);

            //---------------------------------- ASSERT -------------------------------------

            Employee insertedEmployee = EmployeeBLL.GetEmployeeByEmployeeId(newEmployeeId);
            string ACTUAL_EXTENSION = insertedEmployee.Extension;

            Assert.AreEqual(EXPECTED_EXTENSION, ACTUAL_EXTENSION, "Extension was not saved with null value.");
        }

        [TestMethod()]
        public void Photo_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //---------------------------------- ARRANGE -------------------------------------

            Employee newEmployeeObjectWithValidSampleData = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            const byte[] EXPECTED_PHOTO = null;
            newEmployeeObjectWithValidSampleData.Photo = EXPECTED_PHOTO;

            //---------------------------------- ACT -------------------------------------
            
            int newEmployeeId = EmployeeBLL.CreateNewEmployee(newEmployeeObjectWithValidSampleData);

            //---------------------------------- ASSERT -------------------------------------

            Employee insertedEmployee = EmployeeBLL.GetEmployeeByEmployeeId(newEmployeeId);
            byte[] ACTUAL_PHOTO = insertedEmployee.Photo;

            Assert.AreEqual(EXPECTED_PHOTO, ACTUAL_PHOTO, "Photo was not saved with null value.");
        }

        [TestMethod()]
        public void Notes_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //---------------------------------- ARRANGE -------------------------------------
            
            Employee newEmployeeObjectWithValidSampleData = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            const string EXPECTED_NOTES = null;
            newEmployeeObjectWithValidSampleData.Notes = EXPECTED_NOTES;

            //---------------------------------- ACT -------------------------------------
            
            int newEmployeeId = EmployeeBLL.CreateNewEmployee(newEmployeeObjectWithValidSampleData);

            //---------------------------------- ASSERT -------------------------------------

            Employee insertedEmployee = EmployeeBLL.GetEmployeeByEmployeeId(newEmployeeId);
            string ACTUAL_NOTES = insertedEmployee.Notes;
            
            Assert.AreEqual(EXPECTED_NOTES, ACTUAL_NOTES, "Notes was not saved with null value.");
        }

        [TestMethod()]
        public void ReportsTo_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //---------------------------------- ARRANGE -------------------------------------

            Employee newEmployeeObjectWithValidSampleData = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            int? EXPECTED_REPORTSTO = null;
            newEmployeeObjectWithValidSampleData.ReportsTo = EXPECTED_REPORTSTO;

            //---------------------------------- ACT -------------------------------------
            
            int newEmployeeId = EmployeeBLL.CreateNewEmployee(newEmployeeObjectWithValidSampleData);

            //---------------------------------- ASSERT -------------------------------------

            Employee insertedEmployee = EmployeeBLL.GetEmployeeByEmployeeId(newEmployeeId);
            int? ACTUAL_REPORTSTO = insertedEmployee.ReportsTo;

            Assert.AreEqual(EXPECTED_REPORTSTO, ACTUAL_REPORTSTO, "ReportsTo was not saved with null value.");
        }
        
    }
}
