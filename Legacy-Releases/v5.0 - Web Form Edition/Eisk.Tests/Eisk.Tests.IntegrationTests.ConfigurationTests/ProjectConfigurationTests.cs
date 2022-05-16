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
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using Eisk.Helpers;
using Eisk.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eisk.Tests.IntegrationTests.ConfigurationTests
{
    /// <summary>
    /// Summary description for ProjectConfigurationTests
    /// </summary>
    [TestClass]
    public class ProjectConfigurationTests
    {
        public ProjectConfigurationTests()
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
            //TestDataHelper.CreateSchema();
        }
        #endregion

        [TestMethod]
        [DeploymentItem("..\\Eisk.Tests\\Eisk.Tests.IntegrationTests.ConfigurationTests\\App_Data\\ConfigurationTestSettings.xml")]
        public void FileTest_LinkXml()
        {
            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            xDoc.Load("ConfigurationTestSettings.xml");
        }

        [TestMethod]
        [DeploymentItem("..\\Eisk.Tests\\Eisk.Tests.IntegrationTests.ConfigurationTests\\App_Data\\ConfigurationTestSettings.xml")]
        [DataSource("MyXmlDataSource")]
        public void LinkTest_ListingPage_ShouldPassIfFound()
        {
            string urlToTest = testContextInstance.DataRow["EmployeeListingPage"].ToString();
            HttpStatusCode result = new WebRequestHelper().GetWebpageStatusCode(new Uri(urlToTest), RequiredAccess.Public);
            Assert.IsTrue(result == HttpStatusCode.OK, result.ToString());
        }

        [TestMethod]
        [DeploymentItem("..\\Eisk.Tests\\Eisk.Tests.IntegrationTests.ConfigurationTests\\App_Data\\ConfigurationTestSettings.xml")]
        [DataSource("MyXmlDataSource")]
        public void LinkTest_AdminSecuredDefaultPage_ShouldPassIfFound()
        {
            string urlToTest = testContextInstance.DataRow["AdminSecuredDefaultPage"].ToString();
            string urlToLogin = testContextInstance.DataRow["LoginPage"].ToString();
            WebRequestHelper webRequestHelper = new WebRequestHelper(urlToLogin, "any", "any");
            HttpStatusCode result = webRequestHelper.GetWebpageStatusCode(new Uri(urlToTest), RequiredAccess.Admin);
            Assert.IsTrue(result == HttpStatusCode.OK, result.ToString());
        }

        [TestMethod]
        [DeploymentItem("..\\Eisk.Tests\\Eisk.Tests.IntegrationTests.ConfigurationTests\\App_Data\\ConfigurationTestSettings.xml")]
        [DataSource("MyXmlDataSource")]
        public void LinkTest_MemberSecuredDefaultPage_ShouldPassIfFound()
        {
            string urlToTest = testContextInstance.DataRow["MemberSecuredDefaultPage"].ToString();
            string urlToLogin = testContextInstance.DataRow["LoginPage"].ToString();
            WebRequestHelper webRequestHelper = new WebRequestHelper(urlToLogin, "any1", "any1");
            HttpStatusCode result = webRequestHelper.GetWebpageStatusCode(new Uri(urlToTest), RequiredAccess.Member);
            Assert.IsTrue(result == HttpStatusCode.OK, result.ToString());
        }

        [TestMethod]
        public void EmailTest_SendAnEmail_ShouldPassIfSuccessfullySent()
        {
            try
            {
                Emailer.SendMail("ashraf@mvps.com", "joy_csharp@yahoo.com", "[ My Site ] at:" + DateTime.Now.ToString(), "test", null);
            }
            catch (SmtpException ex)
            {
                Assert.Fail("Send email is failed with the message: " + ex.ToString());
            }
            catch (Exception ex2)
            {
                Assert.Fail("Send email is failed with the message: " + ex2.Message);
                throw;
            }

        }

        [TestMethod]
        public void ReferencedAssembliesTest_LoadsAllReferenceDll_PassesIfAllReferringDllExistsPhysically()
        {
            // Get the executing assembly
            Assembly asm = Assembly.GetExecutingAssembly();
            // Get the assemblies that are referenced
            AssemblyName[] refAsms = asm.GetReferencedAssemblies();
            // Loop through and try to load each assembly
            foreach (AssemblyName refAsmName in refAsms)
            {
                try
                {
                    Assembly.Load(refAsmName);
                    Console.WriteLine(refAsmName.FullName);
                }
                catch (FileNotFoundException)
                {
                    // Missing assembly
                    Assert.Fail(refAsmName.FullName + " failed to load");
                }
            }
        }
       
    }
}
