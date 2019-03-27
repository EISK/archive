using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TeamSystem.Data.UnitTesting;
using Eisk.TestHelpers;

namespace Eisk.TestHelpers
{
    /// <summary>
    /// The TestAssemblySetup class contains two methods named BasicSetup and BasicCleanup having two attributes AssemblyInitialize and AssemblyCleanup .NET attribute enables us to perform automated setup operations, such as test data generation etc.  
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    [TestClass()]
    public sealed class TestAssemblySetup
    {
        TestAssemblySetup() { }

        [AssemblyInitialize()]
        public static void BasicSetup(TestContext testContext)
        {
            //WebServerHelper.StartWebServer();
            //TestDataHelper.GenerateTestData();
        }

        [AssemblyCleanup()]
        public static void BasicCleanup()
        {
            //TestHelper.CleanTestData();
            //TestHelper.CleanSchema();
        }
    }
}
