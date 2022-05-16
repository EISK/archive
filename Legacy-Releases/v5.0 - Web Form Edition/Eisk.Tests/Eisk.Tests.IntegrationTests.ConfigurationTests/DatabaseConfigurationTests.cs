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
using Eisk.DataAccessLayer;
using Eisk.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eisk.Tests.IntegrationTests.ConfigurationTests
{
    [TestClass]
    public class DatabaseConfigurationTests
    {
        public DatabaseConfigurationTests()
        {
            
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) 
        {
        }
        #endregion

        [TestMethod]
        public void ConnectionTest_OpensAConnection_ShouldPassIfSuccessful()
        {
            try
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    db.Connection.Open();
                    db.Connection.Close();
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void SchemaGenerationTest_RunsSchemaGenerationScript_ShouldPassIfSuccessful()
        {
            TransactionHelper.TransactionStart();

            try
            {
                TestDataHelper.CreateSchema();
            }
            catch (Exception e)
            {
                Assert.Fail("Schema Generation is failed with the message: " + e.Message);
                throw;
            }

            TransactionHelper.TransactionLeave();
        }

        [TestMethod]
        public void DataGenerationTest_RunsDataGenerationScript_ShouldPassIfSuccessful()
        {
            TransactionHelper.TransactionStart();

            try
            {
                TestDataHelper.CleanTestData();
                TestDataHelper.GenerateTestData();
            }
            catch (Exception e)
            {
                Assert.Fail("Data Generation is failed with the message: " + e.Message);
                throw;
            }

            TransactionHelper.TransactionLeave();
        }

        [TestMethod]
        public void DataCleanupTest_RunsDataCleanupScript_ShouldPassIfSuccessful()
        {
            TransactionHelper.TransactionStart();

            try
            {
                TestDataHelper.CleanTestData();
            }
            catch (Exception e)
            {
                Assert.Fail("Data Cleanup is failed with the message: " + e.Message);
                throw;
            }

            TransactionHelper.TransactionLeave();
        }

        [TestMethod]
        public void SchemaCleanupTest_RunsSchemaCleanupScript_ShouldPassIfSuccessful()
        {
            TransactionHelper.TransactionStart();

            try
            {
                TestDataHelper.CleanSchema();
            }
            catch (Exception e)
            {
                Assert.Fail("Schema Cleanup is failed with the message: " + e.Message);
                throw;
            }

            TransactionHelper.TransactionLeave();
        }

    }
}
