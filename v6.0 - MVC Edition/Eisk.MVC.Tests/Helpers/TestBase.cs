/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2013
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Eisk.Helpers
{
    public class TestBase
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            //Initialize the dependency container to clear any explicit mapping (non-config) done by previous tests
            //Initializing depency container in TestInitialize method is required if we want to mix integration and mock test together.
            //DependencyHelper.Initialize();
        }
    }

   public class IntegrationTestBase:TestBase
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            //Generate test data
            TestDataHelper.InitializeSchemaAndData(@"..\..\..\Eisk.MVC\App_Data\TestData.xml");
        }
        
    }
}
